using Delta.Data;
using Delta.Helpers;
using Delta.Models;
using Delta.Models.Dtos;
using Microsoft.EntityFrameworkCore;


namespace Delta.Services.CompanyService;

public class CompanyService : ICompanyService
{
    private readonly DeltaDbContext _context;
    private readonly IWebHostEnvironment _environment;

    public CompanyService(DeltaDbContext context, IWebHostEnvironment environment)
    {
        _context = context;
        _environment = environment;
    }


    public async Task<IEnumerable<CompanyDto>> GetCompaniesAsync(int? categoryId = null)
    {
        return await _context.Companies
            .Where(p => categoryId == null || p.Id == categoryId)
            // .Include(p => p.Category)
            .Select(p => new CompanyDto
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Logo = p.Logo,
            }).ToListAsync();
    }



    public async Task<CompanyDto?> GetCompanyAsync(int id)
    {
        return await _context.Companies
            .Where(p => p.Id == id)
            // .Include(p => p.Category)
            .Select(p => new CompanyDto
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Logo = p.Logo
            }).FirstOrDefaultAsync();
    }
    

    public async Task<bool> AddCompanyAsync(CompanyDto company)
    {
        _context.Companies.Add(new Company
        {
            Name = company.Name,
            Description = company.Description,
            Logo = company.Logo
        });
    
        var savedCount = await _context.SaveChangesAsync();
    
        return savedCount > 0;
    }
    
    
    public async Task<string> SaveCompanyImageAsync(IFormFile file)
    {
        var uniqueFileName = FileHelper.GetUniqueFileName(file.FileName);
        var uploadDirectory = Path.Combine(_environment.WebRootPath, "images", "companies");
        var filePath = Path.Combine(uploadDirectory, uniqueFileName);
        Directory.CreateDirectory(Path.GetDirectoryName(filePath) ?? throw new InvalidOperationException());
        await file.CopyToAsync(new FileStream(filePath, FileMode.Create));
        return uniqueFileName;
    }

    // public async Task<IEnumerable<CompanyModel>> GetCompaniesAsync()
    // {
    //     return await _context.Companies
    //         .Select(r => new CompanyModel
    //         {
    //             Id = r.Id,
    //             Name = r.Name,
    //             Description = r.Description,
    //             Logo = r.Logo
    //         }).ToListAsync();
    // }
    
    public async Task<bool> DeleteCompanyAsync(int id)
    {
        var company = await _context.Companies.FindAsync(id);
        if (company is null)
            return false;
    
        _context.Companies.Remove(company);
        var saveCount = await _context.SaveChangesAsync();
    
        return saveCount > 0;
    }

    public async Task<CompanyDto?> UpdateCompanyAsync(CompanyDto company)
    {
        var companyToUpdate = await _context.Companies.FindAsync(company.Id);
        if (companyToUpdate is null)
            return null;
        
        companyToUpdate.Name = company.Name;
        companyToUpdate.Description = company.Description;
        companyToUpdate.Logo = company.Logo;
        _context.Companies.Update(companyToUpdate);
        
        var savedCount = await _context.SaveChangesAsync();
        if (savedCount <= 0)
            return null;

        var companyDto = new CompanyDto
        {
            Id = companyToUpdate.Id,
            Name = companyToUpdate.Name,
            Description = companyToUpdate.Description,
            Logo = companyToUpdate.Logo
        };

        return companyDto;
    }
}









