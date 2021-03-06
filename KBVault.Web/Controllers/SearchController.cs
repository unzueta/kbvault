﻿using KBVault.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KBVault.Web.Models.Public;
using KBVault.Web.Helpers;
using KBVault.Dal;
using KBVault.Dal.Entities;

namespace KBVault.Web.Controllers
{
    public class SearchController : KbVaultPublicController
    {        
        [HttpPost]
        public ActionResult Do(SearchFormViewModel model)
        {
            try
            {
                if (string.IsNullOrEmpty(model.SearchKeyword))
                {
                    return RedirectToAction("Index","Home");
                }
                string articlePrefix = Settings.ArticlePrefix;
                if (!string.IsNullOrEmpty(articlePrefix))
                {

                    if (model.SearchKeyword.Length > articlePrefix.Length + 1 &&
                        model.SearchKeyword.Substring(0, articlePrefix.Length + 1) == articlePrefix + "-")
                    {
                        string articleId = model.SearchKeyword.Substring(articlePrefix.Length + 1);
                        model.ArticleId = Convert.ToInt32(articleId);
                    }

                    if (model.ArticleId > 0)
                    {
                        Article article = null;
                        using (var db = new KbVaultContext())
                        {
                            article = db.PublishedArticles().FirstOrDefault(a => a.Id == model.ArticleId);
                        }
                        if (article != null)
                            return RedirectToRoute("Default", new {controller = "Home", action = "Detail", id = article.SefName});
                    }                    
                }
                if (model.CurrentPage == 0)
                    model.CurrentPage++;
                //TODO: Make result count configurable
                model.Results = KbVaultLuceneHelper.DoSearch(model.SearchKeyword, model.CurrentPage,10);
                
                return View( model);
            }catch(Exception ex)
            {
                Log.Error(ex);
                throw;
            }
        }

        [HttpPost]
        public JsonResult More(SearchFormViewModel model)
        {
            JsonOperationResponse result = new JsonOperationResponse();
            try
            {                
                model.CurrentPage++;
                model.Results = KbVaultLuceneHelper.DoSearch(model.SearchKeyword, model.CurrentPage, 1);
                result.Successful = true;
                result.Data = model;
               
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                result.ErrorMessage = ex.Message;
            }
            return Json(result);
        }

        [HttpPost]
        public JsonResult Ajax(string id)
        {
            JsonOperationResponse result = new JsonOperationResponse();
            try
            {

                if (Request.IsAjaxRequest())
                {
                    List<KbSearchResultItemViewModel> items = KbVaultLuceneHelper.DoSearch(id,1,10); //Request.Form["txtSearch"]);
                    result.Data = items;
                    result.Successful = true;
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                result.ErrorMessage = ex.Message;

            }
            return Json(result);
        }

    }
}
