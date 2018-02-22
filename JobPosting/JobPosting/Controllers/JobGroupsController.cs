﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JobPosting.DAL;
using JobPosting.Models;

namespace JobPosting.Controllers
{
    public class JobGroupsController : Controller
    {
        private JBEntities db = new JBEntities();

        // GET: JobGroups
        public ActionResult Index()
        {
            return View(db.JobGroups.ToList());
        }

        // GET: JobGroups/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobGroup jobGroup = db.JobGroups.Find(id);
            if (jobGroup == null)
            {
                return HttpNotFound();
            }
            return View(jobGroup);
        }

        // GET: JobGroups/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: JobGroups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,GroupTitle")] JobGroup jobGroup)
        {
            if (ModelState.IsValid)
            {
                db.JobGroups.Add(jobGroup);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(jobGroup);
        }

        // GET: JobGroups/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobGroup jobGroup = db.JobGroups.Find(id);
            if (jobGroup == null)
            {
                return HttpNotFound();
            }
            return View(jobGroup);
        }

        // POST: JobGroups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,GroupTitle")] JobGroup jobGroup)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jobGroup).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(jobGroup);
        }

        // GET: JobGroups/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobGroup jobGroup = db.JobGroups.Find(id);
            if (jobGroup == null)
            {
                return HttpNotFound();
            }
            return View(jobGroup);
        }

        // POST: JobGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            JobGroup jobGroup = db.JobGroups.Find(id);
            db.JobGroups.Remove(jobGroup);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}