using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BethanysPieShop.Models;
using BethanysPieShop.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BethanysPieShop.Controllers
{
    public class SiteController : Controller
    {

        private readonly ISiteRepository _siteRepository;
        private readonly ISystemCodeRepository _systemCodeRepository;

        public SiteController(ISiteRepository siteRepository, ISystemCodeRepository systemCodeRepository)
        {
            _siteRepository = siteRepository;
            _systemCodeRepository = systemCodeRepository;
        }

        [Authorize()]
        public IActionResult Index(Guid PropertyTypeId)
        {
            try
            {
                //var sites = _siteRepository.GetAllSites().OrderBy(p => p.SiteId);
                //List<SystemCode> myList = _systemCodeRepository.GetAllSystemCodes().ToList();
                //SiteViewModel _siteViewModel = new SiteViewModel();
                //_siteViewModel.Sites = sites.ToList();
                //_siteViewModel.SystemCodes = myList;
                //
                SiteViewModel _siteViewModel = SetData(PropertyTypeId);
                if (_siteViewModel.SystemCodes.Count > 0 && PropertyTypeId == Guid.Empty)
                    _siteViewModel.SelectedPropertyTypeValue = _siteViewModel.SystemCodes[0].Value;
                if (_siteViewModel.SystemCodes.Count > 0 && PropertyTypeId != Guid.Empty)
                {
                    _siteViewModel.SelectedPropertyTypeValue = _siteViewModel.SystemCodes.Where(p => p.SystemCodeId == PropertyTypeId).Select(p => p.Value).FirstOrDefault();
                    _siteViewModel.SelectedPropertyTypeId = _siteViewModel.SystemCodes.Where(p => p.SystemCodeId == PropertyTypeId).Select(p => p.SystemCodeId).FirstOrDefault();
                }
                return View(_siteViewModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SelectedIndexChange([Bind] SiteViewModel siteViewModel)
        {
            SiteViewModel _siteViewModel = SetData(siteViewModel.SelectedPropertyTypeId);
            _siteViewModel.SelectedPropertyTypeId = siteViewModel.SelectedPropertyTypeId;
            _siteViewModel.SelectedPropertyTypeValue = siteViewModel.SelectedPropertyTypeValue;
            return RedirectToAction(nameof(Index), new { PropertyTypeId = _siteViewModel.SelectedPropertyTypeId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Return([Bind] SiteViewModel siteViewModel)
        {
            return RedirectToAction(nameof(Index));
        }


        private SiteViewModel SetData(Guid propertyTypeId)
        {
            List<Site> sites = _siteRepository.GetAllSites().OrderBy(p => p.SiteId).ToList();
            if (propertyTypeId != Guid.Empty)
                sites = sites.Where(p => p.PropertyTypeId == propertyTypeId).ToList();
            List<SystemCode> myList = _systemCodeRepository.GetAllSystemCodes().ToList();
            SiteViewModel _siteViewModel = new SiteViewModel();
            _siteViewModel.Sites = sites.ToList();
            _siteViewModel.SystemCodes = myList;
            return _siteViewModel;
        }

        [HttpGet]
        public IActionResult EditSite(Guid Id, String Code)//
        {
            AddSiteViewModel addSiteViewModel = new AddSiteViewModel();
            List<SystemCode> myList = _systemCodeRepository.GetAllSystemCodes().ToList();
            addSiteViewModel.SystemCodes = myList;
            var site = _siteRepository.GetSiteById(Id);
            addSiteViewModel.Site = site;
            if (site == null)
            {
                NotFound();
            }
            return View(addSiteViewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditSite([Bind] Site site)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    _siteRepository.Update(site);
                    //_siteRepository.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SiteExists(site.SiteId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(site);
        }


        private bool SiteExists(Guid id)
        {
            return _siteRepository.GetAllSites().Any(s => s.SiteId == id);
        }

        [HttpGet]
        public IActionResult AddSite()
        {
            AddSiteViewModel addSiteViewModel = new AddSiteViewModel();
            List<SystemCode> myList = _systemCodeRepository.GetAllSystemCodes().ToList();
            addSiteViewModel.SystemCodes = myList;
            return View(addSiteViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddSite([Bind] Site site)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _siteRepository.Add(site);
                    HttpContext.Session.Set("Data", Encoding.ASCII.GetBytes("Data"));
                    //_siteRepository.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(site);
        }

        [HttpGet]
        public IActionResult Info()
        {
            return RedirectToPage("Information");
        }
    }
}