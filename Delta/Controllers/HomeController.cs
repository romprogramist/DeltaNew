﻿using System.Diagnostics;
using Delta.Models;
using Delta.Models.Dtos;
using Delta.Services.Aboutus;
using Delta.Services.CompanyService;
using Delta.Services.ContactService;
using Delta.Services.ProductcategoryService;
using Microsoft.AspNetCore.Mvc;

namespace Delta.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ICompanyService _companyService;
    private readonly IAboutusService _aboutusService;
    private readonly IContactService _contactService;
    private readonly IProductcategoryService _productcategoryService;

    public HomeController(ILogger<HomeController> logger, ICompanyService companyService, IAboutusService aboutusService, IContactService contactService, IProductcategoryService productcategoryService)
    {
        _logger = logger;
        _companyService = companyService;
        _aboutusService = aboutusService;
        _contactService = contactService;
        _productcategoryService = productcategoryService;
    }
    
    
    
    // public async Task<IActionResult> Index()
    // {
    //     var productCategorys = await _productcategoryService.GetProductcategorysAsync();
    //     if (productCategorys == null || productCategorys.Count == 0)
    //         return NotFound("No productCategorys found.");
    //     return View("Index", productCategorys);
    // }
    
    
    public IActionResult Index()
    {
        return View();
    }
    public IActionResult OurProduction()
    {
        return View();
    }
    
    public async Task<IActionResult> Partners()
    {
        var companies = await _companyService.GetAllCompaniesAsync();
    
        if (companies == null || companies.Count == 0)
            return NotFound("No companies found.");
    
        return View("Partners", companies);
    }
    
    public async Task<IActionResult> AboutUs()
    {
        
        var aboutus = await _aboutusService.GetAllAboutusAsync();
    
        if (aboutus == null || aboutus.Count == 0)
            return NotFound("No companies found.");
    
        return View("AboutUs", aboutus);
    }

    public async Task<IActionResult> ContactUs()
    {
        var contact = await _contactService.GetAllContactAsync();
    
        if (contact == null || contact.Count == 0)
            return NotFound("No companies found.");
    
        return View("ContactUs", contact);
    }
    
    public IActionResult Hematology()
    {
        return View();
    }
    public IActionResult OneProductDescription()
    {
        return View();
    }
    public IActionResult HematologyDescription()
    {
        return View();
    }
    public IActionResult HematologyDescriptionBC700720()
    {
        return View();
    }
    public IActionResult IfaPage()
    {
        return View();
    }
    public IActionResult IfaPageMR96A()
    {
        return View();
    }
    public IActionResult IfaPageMW12A()
    {
        return View();
    }
    public IActionResult IfaPng()
    {
        return View();
    }
    public IActionResult Immunochemistry()
    {
        return View();
    }
    public IActionResult Immunochemistry1200()
    {
        return View();
    }
    public IActionResult MicroShake1200()
    {
        return View();
    }
    public IActionResult MicroWash1100()
    {
        return View();
    }
    public IActionResult MicroRead1000()
    {
        return View();
    }
    public IActionResult LaboratoryChemistry()
    {
        return View();
    }
    public IActionResult Immunochemistry900()
    {
        return View();
    }
    public IActionResult Immunochemistry2000()
    {
        return View();
    }
    public IActionResult HematologyDescriptionBC20S()
    {
        return View();
    }
    public IActionResult HematologyDescriptionBC30S()
    {
        return View();
    }
    public IActionResult HematologyDescriptionMythic22()
    {
        return View();
    }
    public IActionResult HematologyDescriptionMythic18()
    {
        return View();
    }
    public IActionResult HematologyDescriptionBC760780()
    {
        return View();
    }
    public IActionResult HematologyDescriptionMyndrayBC5000()
    {
        return View();
    }
    public IActionResult HematologyDescriptionMyndrayBC5150()
    {
        return View();
    }
    public IActionResult StatFax2200()
    {
        return View();
    }
    public IActionResult StatFax2600()
    {
        return View();
    }
    public IActionResult StatFax4200()
    {
        return View();
    }
    public IActionResult StatFax4300()
    {
        return View();
    }
    public IActionResult StatFax4700()
    {
        return View();
    }
    public IActionResult Electrolytes()
    {
        return View();
    }
    public IActionResult ElectrolytesEC90()
    {
        return View();
    }
    public IActionResult IfaMonoBindR()
    {
        return View();
    }
    public IActionResult Biochemistry()
    {
        return View();
    }
    public IActionResult BiochemistryA15()
    {
        return View();
    }
    public IActionResult BiochemistryA25()
    {
        return View();
    }
    public IActionResult BiochemistryBA400()
    {
        return View();
    }
    
    
    public IActionResult BiochemistryBS800BS800M()
    {
        return View();
    }
    public IActionResult BiochemistryBS600()
    {
        return View();
    }
    public IActionResult BiochemistryBA480()
    {
        return View();
    }
    public IActionResult BiochemistryBS230()
    {
        return View();
    }
    public IActionResult BiochemistryBS240Pro()
    {
        return View();
    }
    public IActionResult BiochemistryBA88A()
    {
        return View();
    }
    public IActionResult BiochemistryStatFax4500()
    {
        return View();
    }
    public IActionResult BiochemistryStatFax3300()
    {
        return View();
    }
    public IActionResult BiochemistryStatFax1904()
    {
        return View();
    }
    public IActionResult MocciStudy()
    {
        return View();
    }
    public IActionResult EU3000()
    {
        return View();
    }
    public IActionResult UA66()
    {
        return View();
    }
    public IActionResult HematologyDescriptionELITEH580()
    {
        return View();
    }
    public IActionResult HematologyDescriptionH560()
    {
        return View();
    }
    public IActionResult HematologyDescriptionH360()
    {
        return View();
    }
    public IActionResult BiosystemsA25A15()
    {
        return View();
    }
    public IActionResult BiosystemsBA400()
    {
        return View();
    }
    public IActionResult Biosystems()
    {
        return View();
    }
    public IActionResult IfaCTK()
    {
        return View();
    }
    public IActionResult IfaCanAg()
    {
        return View();
    }
    public IActionResult IfaIBL()
    {
        return View();
    }
    public IActionResult BiochemistryMindray()
    {
        return View();
    }
    public IActionResult EjaculateStudy()
    {
        return View();
    }
    
    public IActionResult SQAV()
    {
        return View();
    }
    public IActionResult QwikChekGold()
    {
        return View();
    }
    public IActionResult VisionSpermBasic()
    {
        return View();
    }
    public IActionResult VisionSpermIntegro()
    {
        return View();
    }
    public IActionResult EU8600()
    {
        return View();
    }
    public IActionResult UA600()
    {
        return View();
    }
    public IActionResult semiAutomaticMindray()
    {
        return View();
    }
    public IActionResult LauraXL()
    {
        return View();
    }
    public IActionResult laura()
    {
        return View();
    }
    public IActionResult Hemostasis()
    {
        return View();
    }
    public IActionResult ECL105()
    {
        return View();
    }
    public IActionResult ECL412()
    {
        return View();
    }
    public IActionResult C3100()
    {
        return View();
    }
    public IActionResult C3510()
    {
        return View();
    }
    public IActionResult C20004()
    {
        return View();
    }
    public IActionResult C20002()
    {
        return View();
    }
    public IActionResult C20001()
    {
        return View();
    } 
    public IActionResult HemostasisErba()
    {
        return View();
    } 
    public IActionResult BioSolea4()
    {
        return View();
    }
    public IActionResult BioSolea2()
    {
        return View();
    }
    public IActionResult Solea100()
    {
        return View();
    }
    
    public IActionResult HemostasisMindray()
    {
        return View();
    }
    
    public IActionResult HemostasisBioLabo()
    {
        return View();
    }
    
    public IActionResult HemostasisDelta()
    {
        return View();
    }
    public IActionResult URS12()
    {
        return View();
    }
    public IActionResult URS10T()
    {
        return View();
    }
    public IActionResult URS2K()
    {
        return View();
    }
    public IActionResult DeltaReg()
    {
        return View();
    }
    
    public IActionResult BiochemistryReagents()
    {
        return View();
    }
    public IActionResult ReagentsFromMindray()
    {
        return View();
    }
    public IActionResult GeneralLaboratoryConsumable()
    {
        return View();
    }
    public IActionResult GeneralLaboratoryConsumableVacutainers()
    {
        return View();
    }
    public IActionResult GeneralLaboratoryConsumableNeedles()
    {
        return View();
    }
    public IActionResult GeneralLaboratoryConsumableEnd()
    {
        return View();
    }
    public IActionResult GeneralLaboratoryConsumableEppendorfs()
    {
        return View();
    }
    public IActionResult GeneralLaboratoryConsumableNotMain()
    {
        return View();
    }
    public IActionResult test()
    {
        return View();
    }
    
    public IActionResult AddACompany()
    {
        return View();
    }

    public IActionResult AdminPanel()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}