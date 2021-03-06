using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GameReview.Models;

namespace GameReview.Controllers
{
    public class AnGamesController : Controller
    {
        private AnGameContext db = new AnGameContext();

        // GET: AnGames
        public ActionResult Index()
        {
            var anGames = db.AnGames.Include(a => a.DevelopedBy).Include(a => a.Genre);
            return View(anGames.ToList());
        }
        //error messsage for review text
        // GET: Error
        public ActionResult Error()
        {
           
            return View();
        }
        //error for score
        // GET: Error
        public ActionResult Error2()
        {

            return View();
        }

        // GET: AnGames/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnGame anGame = db.AnGames.Find(id);
            if (anGame == null)
            {
                return HttpNotFound();
            }
            return View(anGame);
        }

        // GET: AnGames/Create
        public ActionResult Create()
        {
            ViewBag.DeveloperId = new SelectList(db.AnDevelopers, "DeveloperId", "Name");
            ViewBag.GenreID = new SelectList(db.AnGenres, "GenreID", "Name");
            return View();
        }

        // POST: AnGames/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GameId,Name,Description,Platform,ImgSrc,Price,DeveloperId,GenreID,ReviewId")] AnGame anGame)
        {
            if (ModelState.IsValid)
            {
                db.AnGames.Add(anGame);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DeveloperId = new SelectList(db.AnDevelopers, "DeveloperId", "Name", anGame.DeveloperId);
            ViewBag.GenreID = new SelectList(db.AnGenres, "GenreID", "Name", anGame.GenreID);
            return View(anGame);
        }

        // GET: AnGames/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnGame anGame = db.AnGames.Find(id);
            if (anGame == null)
            {
                return HttpNotFound();
            }
            ViewBag.DeveloperId = new SelectList(db.AnDevelopers, "DeveloperId", "Name", anGame.DeveloperId);
            ViewBag.GenreID = new SelectList(db.AnGenres, "GenreID", "Name", anGame.GenreID);
            return View(anGame);
        }

        // POST: AnGames/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GameId,Name,Description,Platform,ImgSrc,Price,DeveloperId,GenreID,ReviewId")] AnGame anGame)
        {
            if (ModelState.IsValid)
            {
                db.Entry(anGame).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DeveloperId = new SelectList(db.AnDevelopers, "DeveloperId", "Name", anGame.DeveloperId);
            ViewBag.GenreID = new SelectList(db.AnGenres, "GenreID", "Name", anGame.GenreID);
            return View(anGame);
        }

        // GET: AnGames/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnGame anGame = db.AnGames.Find(id);
            if (anGame == null)
            {
                return HttpNotFound();
            }
            return View(anGame);
        }

        // POST: AnGames/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AnGame anGame = db.AnGames.Find(id);
            db.AnGames.Remove(anGame);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // POST: AnGames/PostReviewReply
        [HttpPost]
        public ActionResult PostReviewReply(ReviewReplyViewModel obj)
        {

            int userid = 1;
            AnReviewReply reply = new AnReviewReply();
            reply.UserId = userid;
            reply.ReviewReplyText = obj.AnReviewReply;
            if (reply.ReviewReplyText == null)
            {
                return RedirectToAction("Error");
            }
            reply.ReviewId = obj.AReviewId;
            db.AnReviewReplys.Add(reply);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        // POST: AnGames/PostReview
        [HttpPost]
        public ActionResult PostReview(string AnReview, string AnReviewScore)
        {
            if(AnReview=="")
            {
                return RedirectToAction("Error");
            }
            try
            {
                int temp;
                temp=Convert.ToInt32(AnReviewScore);

                if (temp >0 | temp < 11)
                {
                    int userid = 2;
                    int anreviewscore = Convert.ToInt32(AnReviewScore);
                    AnReview review = new AnReview();
                    review.UserId = userid;
                    review.ReviewText = AnReview;
                    review.ReviewScore = anreviewscore;


                    db.AnReviews.Add(review);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Error2");
                }
                
            }
            catch
            {
                return RedirectToAction("Error2");
            }
            

        }

        // POST: AnGames/DeleteReview
        [HttpPost]
        public ActionResult DeleteReview(int id)
        {
            AnReview anReview = db.AnReviews.Find(id);
            db.AnReviews.Remove(anReview);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        // POST: AnGames/DeleteReviewReply
        [HttpPost]
        public ActionResult DeleteReviewReply(int id)
        {
            AnReviewReply anReviewReply = db.AnReviewReplys.Find(id);
            db.AnReviewReplys.Remove(anReviewReply);
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
