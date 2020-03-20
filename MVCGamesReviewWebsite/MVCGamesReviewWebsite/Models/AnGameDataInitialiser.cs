﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MVCGamesReviewWebsite.Models
{
    public class AnGameDataInitialiser : DropCreateDatabaseAlways<AnGameContext>

    {
        protected override void Seed(AnGameContext context)
        {

            //Genres
            Genre gen1 = new Genre();
            gen1.GenreId = 1;
            gen1.Name = "Action";
            gen1.Description = "Action paced fun!";
            context.Genres.Add(gen1);

            Genre gen2 = new Genre();
            gen2.GenreId = 2;
            gen2.Name = "Action";
            gen2.Description = "Action paced fun!";
            context.Genres.Add(gen2);

            //developers
            Developer dev1 = new Developer();
            dev1.DeveloperID = 1;
            dev1.Name = "George";
            dev1.Description = "Great Developer";
            context.Developers.Add(dev1);


            Developer dev2 = new Developer();
            dev2.DeveloperID = 2;
            dev2.Name = "Micheal";
            dev2.Description = "Good Developer";
            context.Developers.Add(dev2);

            Developer dev3 = new Developer();
            dev2.DeveloperID = 3;
            dev2.Name = "Steve";
            dev2.Description = "Ok Developer";
            context.Developers.Add(dev2);

            //users
            User user1 = new User();
            user1.UserId = 1;
            user1.Password = "Test1!";
            user1.Email = "TestEmail@hotmail.com";
            context.Users.Add(user1);

            //users
            User user2 = new User();
            user2.UserId = 2;
            user2.Password = "Test1!";
            user2.Email = "TestEmail@hotmail.com";
            context.Users.Add(user2);


            //review
            Review rev1 = new Review();
            rev1.ReviewId = 1;
            rev1.ReviewText = "hello";
            rev1.ReviewedBy = user1;
            rev1.UserId = 1;
            context.Reviews.Add(rev1);

            Review rev2 = new Review();
            rev2.ReviewId = 2;
            rev2.ReviewText = "test";
            rev2.ReviewedBy = user2;
            rev2.UserId = 2;
            context.Reviews.Add(rev2);


            Review rev3 = new Review();
            rev3.ReviewId = 3;
            rev3.ReviewText = "Howdy";
            rev3.ReviewedBy = user1;
            rev3.UserId = 1;
            context.Reviews.Add(rev3);

            Review rev4 = new Review();
            rev4.ReviewId = 4;
            rev4.ReviewText = "Hiya";
            rev4.ReviewedBy = user2;
            rev4.UserId = 2;
            context.Reviews.Add(rev4);

            Review rev5 = new Review();
            rev5.ReviewId = 5;
            rev5.ReviewText = "Hello There";
            rev5.ReviewedBy = user1;
            rev5.UserId = 1;
            context.Reviews.Add(rev5);

            Review rev6 = new Review();
            rev6.ReviewId = 4;
            rev6.ReviewText = "Yo";
            rev6.ReviewedBy = user1;
            rev6.UserId = 1;
            context.Reviews.Add(rev6);




            //games
            AnGame game1 = new AnGame();
            game1.Id = 1;
            game1.GenreId = 1;
            game1.Name = "Minecraft";
            game1.ListReview = new List<Review> {rev5, rev6};
            game1.DevelopedBy = dev1;
            game1.Description = "Lots of fun";
            game1.Genre = gen1;
            game1.Platform = "PC";
            game1.Price= 10m;
            game1.ImgSrc = "data:image/jpeg;base64,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";
            context.AnGames.Add(game1);

            AnGame game2 = new AnGame();
            game2.Id = 2;
            game2.GenreId = 1;
            game2.Name = "Rust";
            game2.ListReview = new List<Review> { rev3, rev4 };
            game2.DevelopedBy = dev2;
            game2.Description = "Infuriating!";
            game2.Genre = gen1;
            game2.Platform = "PC";
            game2.Price = 200m;
            game2.ImgSrc = "https://steamcdn-a.akamaihd.net/steam/apps/252490/capsule_616x353.jpg?t=1572600442";
            context.AnGames.Add(game2);


       
            AnGame game3 = new AnGame();
            game3.Id = 3;
            game3.GenreId = 2;
            game3.Name = "GTA V";
            game3.ListReview = new List<Review> { rev1, rev2 };
            game3.DevelopedBy = dev3;
            game3.Description = "Infuriating!";
            game3.Genre = gen2;
            game3.Platform = "PC";
            game3.Price = 200m;
            game3.ImgSrc = "https://vignette.wikia.nocookie.net/gtawiki/images/7/76/CoverArt-GTAV.png/revision/latest?cb=20130826184215";
            context.AnGames.Add(game3);



            


        


            base.Seed(context);

        }
    }
}