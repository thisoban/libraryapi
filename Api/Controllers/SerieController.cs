﻿using CleanArchitecture.Application.Series.Queries.GetSerie;
using CleanArchitecture.Application.Series.Queries.GetSerieWithPagination;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;
public class SerieController : ApiControllerBase
{
    // GET: SerieController
    public async Task<ActionResult<SerieDto>> Getseries([FromQuery] GetserieQuery query)
    {
        return await Mediator.Send(query);
    }

    // GET: SerieController/Details/5
    public ActionResult Details(int id)
    {
        return View();
    }

    // GET: SerieController/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: SerieController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(IFormCollection collection)
    {
        try
        {
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    // GET: SerieController/Edit/5
    public ActionResult Edit(int id)
    {
        return View();
    }

    // POST: SerieController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id, IFormCollection collection)
    {
        try
        {
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    // GET: SerieController/Delete/5
    public ActionResult Delete(int id)
    {
        return View();
    }

    // POST: SerieController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(int id, IFormCollection collection)
    {
        try
        {
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }
}
