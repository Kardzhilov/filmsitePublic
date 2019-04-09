using DAL;
using FilmSiteAdministration.Model;
using Model;
using SharedLogic;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DAL
{
    public class DBSeeder : DropCreateDatabaseAlways<DB>
    {
        protected override void Seed(DB context)
        {
            var MovieModelDAL1 = new MovieModelDAL
            {
                Title = "The Dark Knight",
                Year = 2008,
                Rated = "PG-13",
                Runtime = "152 min",
                Genre = "Action, Crime, Drama",
                Director = "Christopher Nolan",
                Plot = "When the menace known as the Joker emerges from his mysterious past, he wreaks havoc and chaos on the people of Gotham. The Dark Knight must accept one of the greatest psychological and physical tests of his ability to fight injustice.",
                Poster = "https://m.media-amazon.com/images/M/MV5BMTMxNTMwODM0NF5BMl5BanBnXkFtZTcwODAyMTk2Mw@@.jpg",
                ImdbRating = 9.1F,
                ScreenShot = "https://fuwadabrar.files.wordpress.com/2014/11/0468569_1.jpg"
            };
            
            var film2 = new MovieModelDAL
            {
                Title = "The Matrix",
                Year = 1999,
                Rated = "R",
                Runtime = "136 min",
                Genre = "Action, Sci-Fi",
                Director = "Lana Wachowski, Lilly Wachowski",
                Plot = "A computer hacker learns from mysterious rebels about the true nature of his reality and his role in the war against its controllers.",
                Poster = "https://m.media-amazon.com/images/M/MV5BNzQzOTk3OTAtNDQ0Zi00ZTVkLWI0MTEtMDllZjNkYzNjNTc4L2ltYWdlXkEyXkFqcGdeQXVyNjU0OTQ0OTY@.jpg",
                ImdbRating = 8.7F,
                ScreenShot = "https://images.amcnetworks.com/ifc.com/wp-content/uploads/2012/08/081312-the-matrix.jpg"
            };

            var newMovieModelDAL0 = new MovieModelDAL
            {
                Title = "Titanic",
                Year = 1997,
                Rated = "PG-13",
                Runtime = "194 min",
                Genre = "Drama, Romance",
                Plot = "A seventeen-year-old aristocrat falls in love with a kind but poor artist aboard the luxurious, ill-fated R.M.S. Titanic.",
                Poster = "https://m.media-amazon.com/images/M/MV5BMDdmZGU3NDQtY2E5My00ZTliLWIzOTUtMTY4ZGI1YjdiNjk3XkEyXkFqcGdeQXVyNTA4NzY1MzY@.jpg",
                ImdbRating = 7.8F,
                ScreenShot = "https://thumbs-prod.si-cdn.com/vsqJ-lRHmOhPZGy0TUNA5b762PU=/800x600/filters:no_upscale()/https://public-media.smithsonianmag.com/filer/d6/e1/d6e133fd-2a8f-42b6-bc1a-12076f6d498c/screen_shot_2016-02-03_at_15114_pm.png"
            };

            var newMovieModelDAL1 = new MovieModelDAL
            {
                Title = "The Incredibles",
                Year = 2004,
                Rated = "PG",
                Runtime = "115 min",
                Genre = "Family, Animation, Action, Adventure",
                Plot = "A family of undercover superheroes, while trying to live the quiet suburban life, are forced into action to save the world.",
                Poster = "https://m.media-amazon.com/images/M/MV5BMTY5OTU0OTc2NV5BMl5BanBnXkFtZTcwMzU4MDcyMQ@@.jpg",
                ImdbRating = 8.0F,
                ScreenShot = "https://wallpapersmug.com/large/d8ea8c/the-incredibles-2-8k-poster.jpg"
            };

            var newMovieModelDAL2 = new MovieModelDAL
            {
                Title = "Coco",
                Year = 2017,
                Rated = "PG",
                Runtime = "105 min",
                Genre = "Family, Animation, Adventure, Comedy",
                Plot = "Aspiring musician Miguel, confronted with his family's ancestral ban on music, enters the Land of the Dead to find his great-great-grandfather, a legendary singer.",
                Poster = "https://m.media-amazon.com/images/M/MV5BYjQ5NjM0Y2YtNjZkNC00ZDhkLWJjMWItN2QyNzFkMDE3ZjAxXkEyXkFqcGdeQXVyODIxMzk5NjA@.jpg",
                ImdbRating = 8.4F,
                ScreenShot = "https://pmcvariety.files.wordpress.com/2017/09/coco1.jpg"
            };
            var newMovieModelDAL3 = new MovieModelDAL
            {
                Title = "Guardians of the Galaxy Vol. 2",
                Year = 2017,
                Rated = "PG-13",
                Runtime = "136 min",
                Genre = "Family, Action, Adventure, Comedy",
                Plot = "The Guardians must fight to keep their newfound family together as they unravel the mystery of Peter Quill's true parentage.",
                Poster = "https://m.media-amazon.com/images/M/MV5BMTg2MzI1MTg3OF5BMl5BanBnXkFtZTgwNTU3NDA2MTI@.jpg",
                ImdbRating = 7.7F,
                ScreenShot = "http://www.scified.com/articles/sm/guardians-of-the-galaxy-vol2-concept-art-reveals-new-character-mantis-14.jpg"
            };
            var newMovieModelDAL4 = new MovieModelDAL
            {
                Title = "Moana",
                Year = 2016,
                Rated = "PG",
                Runtime = "107 min",
                Genre = "Family, Animation, Adventure, Comedy",
                Plot = "In Ancient Polynesia, when a terrible curse incurred by the Demigod Maui reaches Moana's island, she answers the Ocean's call to seek out the Demigod to set things right.",
                Poster = "https://m.media-amazon.com/images/M/MV5BMjI4MzU5NTExNF5BMl5BanBnXkFtZTgwNzY1MTEwMDI@.jpg",
                ImdbRating = 7.6F,
                ScreenShot = "https://pmcvariety.files.wordpress.com/2016/11/moana-4.jpg"
            };
            var newMovieModelDAL5 = new MovieModelDAL
            {
                Title = "The Lion King",
                Year = 1994,
                Rated = "G",
                Runtime = "88 min",
                Genre = "Family, Animation, Adventure, Drama",
                Plot = "A Lion cub crown prince is tricked by a treacherous uncle into thinking he caused his father's death and flees into exile in despair, only to learn in adulthood his identity and his responsibilities.",
                Poster = "https://m.media-amazon.com/images/M/MV5BYTYxNGMyZTYtMjE3MS00MzNjLWFjNmYtMDk3N2FmM2JiM2M1XkEyXkFqcGdeQXVyNjY5NDU4NzI@.jpg",
                ImdbRating = 8.5F,
                ScreenShot = "https://timedotcom.files.wordpress.com/2016/09/the-lion-king.jpg"
            };
            var newMovieModelDAL6 = new MovieModelDAL
            {
                Title = "Finding Nemo",
                Year = 2003,
                Rated = "G",
                Runtime = "100 min",
                Genre = "Family, Animation, Adventure, Comedy",
                Plot = "After his son is captured in the Great Barrier Reef and taken to Sydney, a timid clownfish sets out on a journey to bring him home.",
                Poster = "https://m.media-amazon.com/images/M/MV5BZjMxYzBiNjUtZDliNC00MDAyLTg3N2QtOWNjNmNhZGQzNDg5XkEyXkFqcGdeQXVyNjE2MjQwNjc@.jpg",
                ImdbRating = 8.1F,
                ScreenShot = "https://m.media-amazon.com/images/M/MV5BMjMwMDYxNTUyMl5BMl5BanBnXkFtZTcwNTIwMjQ4Nw@@._V1_CR0,60,640,360_AL_UX477_CR0,0,477,268_AL_.jpg"
            };
            var newMovieModelDAL7 = new MovieModelDAL
            {
                Title = "The Lego MovieModelDAL",
                Year = 2014,
                Rated = "PG",
                Runtime = "100 min",
                Genre = "Family, Animation, Action, Adventure",
                Plot = "An ordinary LEGO construction worker, thought to be the prophesied as \"special\", is recruited to join a quest to stop an evil tyrant from gluing the LEGO universe into eternal stasis.",
                Poster = "https://m.media-amazon.com/images/M/MV5BMTg4MDk1ODExN15BMl5BanBnXkFtZTgwNzIyNjg3MDE@.jpg",
                ImdbRating = 7.8F,
                ScreenShot = "https://i.ytimg.com/vi/fZ_JOBCLF-I/maxresdefault.jpg"
            };
            var newMovieModelDAL8 = new MovieModelDAL
            {
                Title = "Harry Potter and the Sorcerer's Stone",
                Year = 2001,
                Rated = "PG",
                Runtime = "152 min",
                Genre = "Adventure, Family, Fantasy",
                Plot = "An orphaned boy enrolled in a school of wizardry, where he learns the truth about himself, his family and the terrible evil that haunts the magical world.",
                Poster = "https://m.media-amazon.com/images/M/MV5BNjQ3NWNlNmQtMTE5ZS00MDdmLTlkZjUtZTBlM2UxMGFiMTU3XkEyXkFqcGdeQXVyNjUwNzk3NDc@.jpg",
                ImdbRating = 7.6F,
                ScreenShot = "http://cdn-static.denofgeek.com/sites/denofgeek/files/styles/main_wide/public/2016/11/harry-potter-and-the-sorcerers-stone-52243291c968a.jpg"
            };
            var newMovieModelDAL9 = new MovieModelDAL
            {
                Title = "Willy Wonka & the Chocolate Factory",
                Year = 1971,
                Rated = "G",
                Runtime = "100 min",
                Genre = "Family, Fantasy, Musical",
                Plot = "Charlie receives a golden ticket to a factory, his sweet tooth wants going into the lushing candy, it turns out there's an adventure in everything.",
                Poster = "https://ia.media-imdb.com/images/M/MV5BZTllNDU0ZTItYTYxMC00OTI4LThlNDAtZjNiNzdhMWZiYjNmXkEyXkFqcGdeQXVyNzY1NDgwNjQ@.jpg",
                ImdbRating = 7.8F,
                ScreenShot = "https://ksassets.timeincuk.net/wp/uploads/sites/55/2015/10/2015CharlieAndTheChocolateFactory_1971_211015-920x610.jpg"
            };
            var newMovieModelDAL10 = new MovieModelDAL
            {
                Title = "Jurassic Park",
                Year = 1993,
                Rated = "PG-13",
                Runtime = "127 min",
                Genre = "Adventure, Sci-Fi, Thriller",
                Plot = "During a preview tour, a theme park suffers a major power breakdown that allows its cloned dinosaur exhibits to run amok.",
                Poster = "https://m.media-amazon.com/images/M/MV5BMjM2MDgxMDg0Nl5BMl5BanBnXkFtZTgwNTM2OTM5NDE@.jpg",
                ImdbRating = 8.1F,
                ScreenShot = "https://nerdist.com/wp-content/uploads/2018/08/Jurassic-Park-featured.jpg"
            };
            var newMovieModelDAL11 = new MovieModelDAL
            {
                Title = "Goodfellas",
                Year = 1990,
                Rated = "R",
                Runtime = "146 min",
                Genre = "Crime, Drama",
                Plot = "The story of Henry Hill and his life in the mob, covering his relationship with his wife Karen Hill and his mob partners Jimmy Conway and Tommy DeVito in the Italian-American crime syndicate.",
                Poster = "https://m.media-amazon.com/images/M/MV5BY2NkZjEzMDgtN2RjYy00YzM1LWI4ZmQtMjIwYjFjNmI3ZGEwXkEyXkFqcGdeQXVyNzkwMjQ5NzM@.jpg",
                ImdbRating = 8.7F,
                ScreenShot = "http://ichef.bbci.co.uk/wwfeatures/wm/live/1280_640/images/live/p0/2p/r7/p02pr7c4.jpg"
            };
            var newMovieModelDAL12 = new MovieModelDAL
            {
                Title = "Forrest Gump",
                Year = 1994,
                Rated = "PG-13",
                Runtime = "142 min",
                Genre = "Drama, Romance",
                Plot = "The presidencies of Kennedy and Johnson, Vietnam, Watergate, and other history unfold through the perspective of an Alabama man with an IQ of 75.",
                Poster = "https://m.media-amazon.com/images/M/MV5BNWIwODRlZTUtY2U3ZS00Yzg1LWJhNzYtMmZiYmEyNmU1NjMzXkEyXkFqcGdeQXVyMTQxNzMzNDI@.jpg",
                ImdbRating = 8.8F,
                ScreenShot = "https://i.kinja-img.com/gawker-media/image/upload/s--UVKap3m4--/c_scale,f_auto,fl_progressive,q_80,w_800/ghwbyobguv7v7brpjyfe.jpg"
            };
            var newMovieModelDAL13 = new MovieModelDAL
            {
                Title = "Fight Club",
                Year = 1999,
                Rated = "R",
                Runtime = "139 min",
                Genre = "Drama",
                Plot = "An insomniac office worker and a devil-may-care soapmaker form an underground fight club that evolves into something much, much more.",
                Poster = "https://m.media-amazon.com/images/M/MV5BMjJmYTNkNmItYjYyZC00MGUxLWJhNWMtZDY4Nzc1MDAwMzU5XkEyXkFqcGdeQXVyNzkwMjQ5NzM@.jpg",
                ImdbRating = 8.8F,
                ScreenShot = "http://images.amcnetworks.com/ifccenter.com/wp-content/uploads/2011/02/fightclub_1280.png"
            };
            var newMovieModelDAL14 = new MovieModelDAL
            {
                Title = "Groundhog Day",
                Year = 1993,
                Rated = "PG",
                Runtime = "101 min",
                Genre = "Comedy, Fantasy, Romance",
                Plot = "A weatherman finds himself inexplicably living the same day over and over again.",
                Poster = "https://m.media-amazon.com/images/M/MV5BZWIxNzM5YzQtY2FmMS00Yjc3LWI1ZjUtNGVjMjMzZTIxZTIxXkEyXkFqcGdeQXVyNjU0OTQ0OTY@.jpg",
                ImdbRating = 8.0F,
                ScreenShot = "https://www.slashfilm.com/wp/wp-content/images/groundhog-day1.jpg"
            };
            var newMovieModelDAL15 = new MovieModelDAL
            {
                Title = "Braveheart",
                Year = 1995,
                Rated = "R",
                Runtime = "178 min",
                Genre = "Biography, Drama, History",
                Plot = "When his secret bride is executed for assaulting an English soldier who tried to rape her, Sir William Wallace begins a revolt against King Edward I of England.",
                Poster = "https://m.media-amazon.com/images/M/MV5BMzkzMmU0YTYtOWM3My00YzBmLWI0YzctOGYyNTkwMWE5MTJkXkEyXkFqcGdeQXVyNzkwMjQ5NzM@.jpg",
                ImdbRating = 8.4F,
                ScreenShot = "https://www.maxim.com/.image/t_share/MTU0MTU4MzY3MjY1MjY5MDcy/braveheart-execution-promo.jpg"
            };
            var newMovieModelDAL16 = new MovieModelDAL
            {
                Title = "Gladiator",
                Year = 2000,
                Rated = "R",
                Runtime = "155 min",
                Genre = "Action, Adventure, Drama",
                Plot = "When a Roman General is betrayed, and his family murdered by an emperor's corrupt son, he comes to Rome as a gladiator to seek revenge.",
                Poster = "https://m.media-amazon.com/images/M/MV5BMDliMmNhNDEtODUyOS00MjNlLTgxODEtN2U3NzIxMGVkZTA1L2ltYWdlXkEyXkFqcGdeQXVyNjU0OTQ0OTY@.jpg",
                ImdbRating = 8.5F,
                ScreenShot = "http://ichef.bbci.co.uk/wwfeatures/wm/live/1280_640/images/live/p0/6h/21/p06h21cz.jpg"
            };
            var newMovieModelDAL17 = new MovieModelDAL
            {
                Title = "The Lord of the Rings: The Fellowship of the Ring",
                Year = 2001,
                Rated = "PG-13",
                Runtime = "178 min",
                Genre = "Adventure, Drama, Fantasy",
                Plot = "A meek Hobbit from the Shire and eight companions set out on a journey to destroy the powerful One Ring and save Middle-earth from the Dark Lord Sauron.",
                Poster = "https://m.media-amazon.com/images/M/MV5BN2EyZjM3NzUtNWUzMi00MTgxLWI0NTctMzY4M2VlOTdjZWRiXkEyXkFqcGdeQXVyNDUzOTQ5MjY@.jpg",
                ImdbRating = 8.8F,
                ScreenShot = "http://digitalspyuk.cdnds.net/12/47/768x433/gallery_Movies_lotr_fellowship_of_the_ring_1.jpg"
            };

            var MovieModelDALMachine0 = new MovieModelDAL
            {
                Title = "Heat",
                Year = 1995,
                Rated = "R",
                Runtime = "170 min",
                Genre = "Crime, Drama, Thriller",
                Plot = "A group of professional bank robbers start to feel the heat from police when they unknowingly leave a clue at their latest heist.",
                Poster = "https://m.media-amazon.com/images/M/MV5BNDc0YTQ5NGEtM2NkYS00MWRhLThiNzAtNmY3NWU3YzNkMjIyXkEyXkFqcGdeQXVyNzkwMjQ5NzM@.jpg",
                ImdbRating = 8.2F,
                ScreenShot = "https://cdn.gelestatic.it/kataweb/tvzap/2018/03/taglioAlta_001220.jpg",
            };
            context.Movies.Add(MovieModelDALMachine0);

            var MovieModelDALMachine1 = new MovieModelDAL
            {
                Title = "Toy Story",
                Year = 1995,
                Rated = "G",
                Runtime = "81 min",
                Genre = "Animation, Adventure, Comedy",
                Plot = "A cowboy doll is profoundly threatened and jealous when a new spaceman figure supplants him as top toy in a boy's room.",
                Poster = "https://m.media-amazon.com/images/M/MV5BMDU2ZWJlMjktMTRhMy00ZTA5LWEzNDgtYmNmZTEwZTViZWJkXkEyXkFqcGdeQXVyNDQ2OTk4MzI@.jpg",
                ImdbRating = 8.3F,
                ScreenShot = "https://i.ytimg.com/vi/qBWhCkbEEyI/maxresdefault.jpg",
            };
            context.Movies.Add(MovieModelDALMachine1);

            var MovieModelDALMachine2 = new MovieModelDAL
            {
                Title = "Avatar",
                Year = 2009,
                Rated = "PG-13",
                Runtime = "162 min",
                Genre = "Action, Adventure, Fantasy",
                Plot = "A paraplegic marine dispatched to the moon Pandora on a unique mission becomes torn between following his orders and protecting the world he feels is his home.",
                Poster = "https://m.media-amazon.com/images/M/MV5BMTYwOTEwNjAzMl5BMl5BanBnXkFtZTcwODc5MTUwMw@@.jpg",
                ImdbRating = 7.8F,
                ScreenShot = "https://static.independent.co.uk/s3fs-public/thumbnails/image/2017/08/09/08/avatar.jpg",
            };
            context.Movies.Add(MovieModelDALMachine2);

            var MovieModelDALMachine3 = new MovieModelDAL
            {
                Title = "Home Alone",
                Year = 1990,
                Rated = "PG",
                Runtime = "103 min",
                Genre = "Comedy, Family",
                Plot = "An eight-year-old troublemaker must protect his house from a pair of burglars when he is accidentally left home alone by his family during Christmas vacation.",
                Poster = "https://m.media-amazon.com/images/M/MV5BMzFkM2YwOTQtYzk2Mi00N2VlLWE3NTItN2YwNDg1YmY0ZDNmXkEyXkFqcGdeQXVyMTMxODk2OTU@.jpg",
                ImdbRating = 7.5F,
                ScreenShot = "http://www.frukmagazine.com/wp-content/uploads/2015/12/fr-youtube.com_.jpg",
            };
            context.Movies.Add(MovieModelDALMachine3);

            var MovieModelDALMachine4 = new MovieModelDAL
            {
                Title = "Gravity",
                Year = 2013,
                Rated = "PG-13",
                Runtime = "91 min",
                Genre = "Drama, Sci-Fi, Thriller",
                Plot = "Two astronauts work together to survive after an accident which leaves them stranded in space.",
                Poster = "https://m.media-amazon.com/images/M/MV5BNjE5MzYwMzYxMF5BMl5BanBnXkFtZTcwOTk4MTk0OQ@@.jpg",
                ImdbRating = 7.7F,
                ScreenShot = "https://cdn-images-1.medium.com/max/2000/1*R55QZ7u6JQoOrmLU6DULrQ.jpeg",
            };
            context.Movies.Add(MovieModelDALMachine4);

            var MovieModelDALMachine5 = new MovieModelDAL
            {
                Title = "RoboCop",
                Year = 1987,
                Rated = "R",
                Runtime = "102 min",
                Genre = "Action, Crime, Sci-Fi",
                Plot = "In a dystopic and crime-ridden Detroit, a terminally wounded cop returns to the force as a powerful cyborg haunted by submerged memories.",
                Poster = "https://m.media-amazon.com/images/M/MV5BZWVlYzU2ZjQtZmNkMi00OTc3LTkwZmYtZDVjNmY4OWFmZGJlXkEyXkFqcGdeQXVyMTQxNzMzNDI@.jpg",
                ImdbRating = 7.5F,
                ScreenShot = "https://i0.wp.com/doblu.com/wp-content/uploads/2010/10/robo2cop3405.jpg",
            };
            context.Movies.Add(MovieModelDALMachine5);

            var MovieModelDALMachine6 = new MovieModelDAL
            {
                Title = "Aliens",
                Year = 1986,
                Rated = "R",
                Runtime = "137 min",
                Genre = "Action, Adventure, Sci-Fi",
                Plot = "Ellen Ripley is rescued by a deep salvage team after being in hypersleep for 57 years. The moon that the Nostromo visited has been colonized, but contact is lost. This time, colonial marines have impressive firepower, but will that be enough?",
                Poster = "https://m.media-amazon.com/images/M/MV5BYzVlMWViZGEtYjEyYy00YWZmLThmZGEtYmM4MDZlN2Q5MmRmXkEyXkFqcGdeQXVyMTQxNzMzNDI@.jpg",
                ImdbRating = 8.4F,
                ScreenShot = "https://i.imgur.com/CSEj3zb.jpg",
            };
            context.Movies.Add(MovieModelDALMachine6);

            var MovieModelDALMachine7 = new MovieModelDAL
            {
                Title = "The Gold Rush",
                Year = 1925,
                Rated = "NOT RATED",
                Runtime = "95 min",
                Genre = "Adventure, Comedy, Drama",
                Plot = "A prospector goes to the Klondike in search of gold and finds it and more.",
                Poster = "https://m.media-amazon.com/images/M/MV5BZjEyOTE4MzMtNmMzMy00Mzc3LWJlOTQtOGJiNDE0ZmJiOTU4L2ltYWdlXkEyXkFqcGdeQXVyNTAyODkwOQ@@.jpg",
                ImdbRating = 8.2F,
                ScreenShot = "http://www.doctormacro.com/Images/Chaplin,%20Charlie/Annex/NRFPT/Annex%20-%20Chaplin,%20Charlie%20(Gold%20Rush,%20The)_NRFPT_22.jpg",
            };
            context.Movies.Add(MovieModelDALMachine7);

            var MovieModelDALMachine8 = new MovieModelDAL
            {
                Title = "The Truman Show",
                Year = 1998,
                Rated = "PG",
                Runtime = "103 min",
                Genre = "Comedy, Drama, Sci-Fi",
                Plot = "An insurance salesman/adjuster discovers his entire life is actually a television show.",
                Poster = "https://m.media-amazon.com/images/M/MV5BMDIzODcyY2EtMmY2MC00ZWVlLTgwMzAtMjQwOWUyNmJjNTYyXkEyXkFqcGdeQXVyNDk3NzU2MTQ@.jpg",
                ImdbRating = 8.1F,
                ScreenShot = "https://cdn-images-1.medium.com/max/1920/0*yvAGSgIHpcxNP9xc.jpg",
            };
            context.Movies.Add(MovieModelDALMachine8);

            var MovieModelDALMachine9 = new MovieModelDAL
            {
                Title = "Batman Begins",
                Year = 2005,
                Rated = "PG-13",
                Runtime = "140 min",
                Genre = "Action, Adventure",
                Plot = "After training with his mentor, Batman begins his fight to free crime-ridden Gotham City from corruption.",
                Poster = "https://m.media-amazon.com/images/M/MV5BZmUwNGU2ZmItMmRiNC00MjhlLTg5YWUtODMyNzkxODYzMmZlXkEyXkFqcGdeQXVyNTIzOTk5ODM@.jpg",
                ImdbRating = 8.3F,
                ScreenShot = "https://static1.comicvine.com/uploads/original/11120/111209888/5243285-batman-begins.0.0.jpg",
            };
            context.Movies.Add(MovieModelDALMachine9);

            var MovieModelDALMachine10 = new MovieModelDAL
            {
                Title = "The Road",
                Year = 2009,
                Rated = "R",
                Runtime = "111 min",
                Genre = "Adventure, Drama",
                Plot = "In a dangerous post-apocalyptic world, an ailing father defends his son as they slowly travel to the sea.",
                Poster = "https://m.media-amazon.com/images/M/MV5BMTAwNzk4NTU3NDReQTJeQWpwZ15BbWU3MDg3OTEyODI@.jpg",
                ImdbRating = 7.3F,
                ScreenShot = "https://i.ytimg.com/vi/Mwq0mgvC1eY/maxresdefault.jpg",
            };
            context.Movies.Add(MovieModelDALMachine10);

            var MovieModelDALMachine11 = new MovieModelDAL
            {
                Title = "O Brother, Where Art Thou?",
                Year = 2000,
                Rated = "PG-13",
                Runtime = "107 min",
                Genre = "Adventure, Comedy, Crime",
                Plot = "In the deep south during the 1930s, three escaped convicts search for hidden treasure while a relentless lawman pursues them.",
                Poster = "https://m.media-amazon.com/images/M/MV5BMjZkOTdmMWItOTkyNy00MDdjLTlhNTQtYzU3MzdhZjA0ZDEyXkEyXkFqcGdeQXVyMTMxODk2OTU@.jpg",
                ImdbRating = 7.8F,
                ScreenShot = "https://images.static-bluray.com/reviews/4844_1.jpg",
            };
            context.Movies.Add(MovieModelDALMachine11);

            var MovieModelDALMachine12 = new MovieModelDAL
            {
                Title = "Blood Diamond",
                Year = 2006,
                Rated = "R",
                Runtime = "143 min",
                Genre = "Adventure, Drama, Thriller",
                Plot = "A fisherman, a smuggler, and a syndicate of businessmen match wits over the possession of a priceless diamond.",
                Poster = "https://m.media-amazon.com/images/M/MV5BZmNjOTEyMzEtNWJiMy00Njg5LTk2OTctMDk3MmEwOWQyZTgzXkEyXkFqcGdeQXVyMTMxODk2OTU@.jpg",
                ImdbRating = 8.0F,
                ScreenShot = "https://m.media-amazon.com/images/M/MV5BMTc4NzQ4NDE3NV5BMl5BanBnXkFtZTcwODIwMzkyMw@@._V1_.jpg",
            };
            context.Movies.Add(MovieModelDALMachine12);

            var MovieModelDALMachine13 = new MovieModelDAL
            {
                Title = "Mad Max: Fury Road",
                Year = 2015,
                Rated = "R",
                Runtime = "120 min",
                Genre = "Action, Adventure, Sci-Fi",
                Plot = "In a post-apocalyptic wasteland, a woman rebels against a tyrannical ruler in search for her homeland with the aid of a group of female prisoners, a psychotic worshiper, and a drifter named Max.",
                Poster = "https://m.media-amazon.com/images/M/MV5BN2EwM2I5OWMtMGQyMi00Zjg1LWJkNTctZTdjYTA4OGUwZjMyXkEyXkFqcGdeQXVyMTMxODk2OTU@.jpg",
                ImdbRating = 8.1F,
                ScreenShot = "https://i.kinja-img.com/gawker-media/image/upload/s--0jH6AmcB--/c_fill,fl_progressive,g_center,h_900,q_80,w_1600/jcw11fxjutjaqo5htjk3.jpg",
            };
            context.Movies.Add(MovieModelDALMachine13);

            var MovieModelDALMachine14 = new MovieModelDAL
            {
                Title = "Black Swan",
                Year = 2010,
                Rated = "R",
                Runtime = "108 min",
                Genre = "Drama, Thriller",
                Plot = "A committed dancer wins the lead role in a production of Tchaikovsky's \"Swan Lake\" only to find herself struggling to maintain her sanity.",
                Poster = "https://m.media-amazon.com/images/M/MV5BNzY2NzI4OTE5MF5BMl5BanBnXkFtZTcwMjMyNDY4Mw@@.jpg",
                ImdbRating = 8.0F,
                ScreenShot = "http://ilarge.lisimg.com/image/1606910/1000full-black-swan-screenshot.jpg",
            };
            context.Movies.Add(MovieModelDALMachine14);

            var MovieModelDALMachine15 = new MovieModelDAL
            {
                Title = "Children of Men",
                Year = 2006,
                Rated = "R",
                Runtime = "109 min",
                Genre = "Drama, Sci-Fi, Thriller",
                Plot = "In 2027, in a chaotic world in which women have become somehow infertile, a former activist agrees to help transport a miraculously pregnant woman to a sanctuary at sea.",
                Poster = "https://m.media-amazon.com/images/M/MV5BMTQ5NTI2NTI4NF5BMl5BanBnXkFtZTcwNjk2NDA2OQ@@.jpg",
                ImdbRating = 7.9F,
                ScreenShot = "http://www.thefocuspull.com/wp-content/uploads/2014/06/children-of-men.png",
            };
            context.Movies.Add(MovieModelDALMachine15);

            var MovieModelDALMachine16 = new MovieModelDAL
            {
                Title = "Pulp Fiction",
                Year = 1994,
                Rated = "R",
                Runtime = "154 min",
                Genre = "Crime, Drama",
                Plot = "The lives of two mob hitmen, a boxer, a gangster's wife, and a pair of diner bandits intertwine in four tales of violence and redemption.",
                Poster = "https://m.media-amazon.com/images/M/MV5BNGNhMDIzZTUtNTBlZi00MTRlLWFjM2ItYzViMjE3YzI5MjljXkEyXkFqcGdeQXVyNzkwMjQ5NzM@.jpg",
                ImdbRating = 8.9F,
                ScreenShot = "http://images.amcnetworks.com/amctv.la/wp-content/uploads/2017/04/Pulp-Fiction1.jpg",
            };
            context.Movies.Add(MovieModelDALMachine16);

            var MovieModelDALMachine17 = new MovieModelDAL
            {
                Title = "Casino",
                Year = 1995,
                Rated = "R",
                Runtime = "178 min",
                Genre = "Crime, Drama",
                Plot = "A tale of greed, deception, money, power, and murder occur between two best friends: a mafia enforcer and a casino executive, compete against each other over a gambling empire, and over a fast living and fast loving socialite.",
                Poster = "https://m.media-amazon.com/images/M/MV5BMTcxOWYzNDYtYmM4YS00N2NkLTk0NTAtNjg1ODgwZjAxYzI3XkEyXkFqcGdeQXVyNTA4NzY1MzY@.jpg",
                ImdbRating = 8.2F,
                ScreenShot = "http://inpraiseofcinema.com/wp-content/uploads/2015/10/Casino1.jpg",
            };
            context.Movies.Add(MovieModelDALMachine17);

            var MovieModelDALMachine18 = new MovieModelDAL
            {
                Title = "Inception",
                Year = 2010,
                Rated = "PG-13",
                Runtime = "148 min",
                Genre = "Action, Adventure, Sci-Fi",
                Plot = "A thief who steals corporate secrets through the use of dream-sharing technology is given the inverse task of planting an idea into the mind of a CEO.",
                Poster = "https://m.media-amazon.com/images/M/MV5BMjAxMzY3NjcxNF5BMl5BanBnXkFtZTcwNTI5OTM0Mw@@.jpg",
                ImdbRating = 8.8F,
                ScreenShot = "https://million-wallpapers.com/wallpapers/0/38/447583961238658.jpg",
            };
            context.Movies.Add(MovieModelDALMachine18);

            var MovieModelDALMachine19 = new MovieModelDAL
            {
                Title = "North by Northwest",
                Year = 1959,
                Rated = "NOT RATED",
                Runtime = "136 min",
                Genre = "Adventure, Mystery, Thriller",
                Plot = "A hapless New York advertising executive is mistaken for a government agent by a group of foreign spies, and is pursued across the country while he looks for a way to survive.",
                Poster = "https://ia.media-imdb.com/images/M/MV5BZDA3NDExMTUtMDlhOC00MmQ5LWExZGUtYmI1NGVlZWI4OWNiXkEyXkFqcGdeQXVyNjc1NTYyMjg@.jpg",
                ImdbRating = 8.3F,
                ScreenShot = "https://i.pinimg.com/originals/73/16/d7/7316d729737b1e89dd3e49a0a87d9d6a.jpg",
            };
            context.Movies.Add(MovieModelDALMachine19);

            var MovieModelDALMachine20 = new MovieModelDAL
            {
                Title = "The Artist",
                Year = 2011,
                Rated = "PG-13",
                Runtime = "100 min",
                Genre = "Comedy, Drama, Romance",
                Plot = "A silent MovieModelDAL star meets a young dancer, but the arrival of talking pictures sends their careers in opposite directions.",
                Poster = "https://m.media-amazon.com/images/M/MV5BMDUyZWU5N2UtOWFlMy00MTI0LTk0ZDYtMzFhNjljODBhZDA5XkEyXkFqcGdeQXVyNzA4ODc3ODU@.jpg",
                ImdbRating = 7.9F,
                ScreenShot = "https://m.media-amazon.com/images/M/MV5BMjA0MjA3NjQxN15BMl5BanBnXkFtZTcwODc4NTM5Ng@@._V1_SX1500_CR0,0,1500,999_AL_.jpg",
            };
            context.Movies.Add(MovieModelDALMachine20);

            var MovieModelDALMachine21 = new MovieModelDAL
            {
                Title = "The Descendants",
                Year = 2011,
                Rated = "R",
                Runtime = "115 min",
                Genre = "Comedy, Drama",
                Plot = "A land baron tries to reconnect with his two daughters after his wife is seriously injured in a boating accident.",
                Poster = "https://m.media-amazon.com/images/M/MV5BMjAyNTA1MTcyN15BMl5BanBnXkFtZTcwNjEyODczNQ@@.jpg",
                ImdbRating = 7.3F,
                ScreenShot = "https://static.fanpage.it/cinemafanpage/wp-content/uploads/2012/02/paramaro1.jpg",
            };
            context.Movies.Add(MovieModelDALMachine21);

            var MovieModelDALMachine22 = new MovieModelDAL
            {
                Title = "The Shawshank Redemption",
                Year = 1994,
                Rated = "R",
                Runtime = "142 min",
                Genre = "Drama",
                Plot = "Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency.",
                Poster = "https://m.media-amazon.com/images/M/MV5BMDFkYTc0MGEtZmNhMC00ZDIzLWFmNTEtODM1ZmRlYWMwMWFmXkEyXkFqcGdeQXVyMTMxODk2OTU@.jpg",
                ImdbRating = 9.3F,
                ScreenShot = "https://img2.looper.com/img/gallery/cult-MovieModelDAL-classics-that-bombed-at-the-box-office/the-shawshank-redemption-1994-1501849190.jpg",
            };
            context.Movies.Add(MovieModelDALMachine22);

            var MovieModelDALMachine23 = new MovieModelDAL
            {
                Title = "The Martian",
                Year = 2015,
                Rated = "PG-13",
                Runtime = "144 min",
                Genre = "Adventure, Drama, Sci-Fi",
                Plot = "An astronaut becomes stranded on Mars after his team assume him dead, and must rely on his ingenuity to find a way to signal to Earth that he is alive.",
                Poster = "https://m.media-amazon.com/images/M/MV5BMTc2MTQ3MDA1Nl5BMl5BanBnXkFtZTgwODA3OTI4NjE@.jpg",
                ImdbRating = 8.0F,
                ScreenShot = "https://www.technobuffalo.com/wp-content/uploads/2015/10/The-Martian-viral-teaser.jpg",
            };
            context.Movies.Add(MovieModelDALMachine23);

            var MovieModelDALMachine24 = new MovieModelDAL
            {
                Title = "Léon: The Professional",
                Year = 1994,
                Rated = "R",
                Runtime = "110 min",
                Genre = "Crime, Drama, Thriller",
                Plot = "Mathilda, a 12-year-old girl, is reluctantly taken in by Léon, a professional assassin, after her family is murdered. Léon and Mathilda form an unusual relationship, as she becomes his protégée and learns the assassin's trade.",
                Poster = "https://m.media-amazon.com/images/M/MV5BZDAwYTlhMDEtNTg0OS00NDY2LWJjOWItNWY3YTZkM2UxYzUzXkEyXkFqcGdeQXVyNTA4NzY1MzY@.jpg",
                ImdbRating = 8.6F,
                ScreenShot = "https://www.avsforum.com/forum/imagehosting/317955630d79524443.jpg",
            };
            context.Movies.Add(MovieModelDALMachine24);

            var MovieModelDALMachine25 = new MovieModelDAL
            {
                Title = "Jaws",
                Year = 1975,
                Rated = "PG",
                Runtime = "124 min",
                Genre = "Adventure, Drama, Thriller",
                Plot = "A local sheriff, a marine biologist and an old seafarer team up to hunt down a great white shark wreaking havoc in a beach resort.",
                Poster = "https://m.media-amazon.com/images/M/MV5BMmVmODY1MzEtYTMwZC00MzNhLWFkNDMtZjAwM2EwODUxZTA5XkEyXkFqcGdeQXVyNTAyODkwOQ@@.jpg",
                ImdbRating = 8.0F,
                ScreenShot = "https://i.pinimg.com/originals/5b/a1/00/5ba1006f75be54fecdfcde93bd83affd.jpg",
            };
            context.Movies.Add(MovieModelDALMachine25);

            var MovieModelDALMachine26 = new MovieModelDAL
            {
                Title = "Lock, Stock and Two Smoking Barrels",
                Year = 1998,
                Rated = "R",
                Runtime = "107 min",
                Genre = "Comedy, Crime",
                Plot = "A botched card game in London triggers four friends, thugs, weed-growers, hard gangsters, loan sharks and debt collectors to collide with each other in a series of unexpected events, all for the sake of weed, cash and two antique shotguns.",
                Poster = "https://m.media-amazon.com/images/M/MV5BMTAyN2JmZmEtNjAyMy00NzYwLThmY2MtYWQ3OGNhNjExMmM4XkEyXkFqcGdeQXVyNDk3NzU2MTQ@.jpg",
                ImdbRating = 8.2F,
                ScreenShot = "https://m.media-amazon.com/images/M/MV5BOTAwNzdkNTktMjRjYi00Zjc1LTk1M2ItZGNkN2RlYzg0ZWEyXkEyXkFqcGdeQXVyMjUyNDk2ODc@._V1_SX1777_CR0,0,1777,962_AL_.jpg",
            };
            context.Movies.Add(MovieModelDALMachine26);

            var MovieModelDALMachine27 = new MovieModelDAL
            {
                Title = "Taxi Driver",
                Year = 1976,
                Rated = "R",
                Runtime = "114 min",
                Genre = "Crime, Drama",
                Plot = "A mentally unstable veteran works as a nighttime taxi driver in New York City, where the perceived decadence and sleaze fuels his urge for violent action, while attempting to liberate a twelve-year-old prostitute.",
                Poster = "https://m.media-amazon.com/images/M/MV5BM2M1MmVhNDgtNmI0YS00ZDNmLTkyNjctNTJiYTQ2N2NmYzc2XkEyXkFqcGdeQXVyNzkwMjQ5NzM@.jpg",
                ImdbRating = 8.3F,
                ScreenShot = "http://3.bp.blogspot.com/-kpQqMnWSdOw/UBzBvlj9e0I/AAAAAAAAAH4/p9QaKr3H_eA/s1600/taxi_driver_4.png",
            };
            context.Movies.Add(MovieModelDALMachine27);

            var MovieModelDALMachine28 = new MovieModelDAL
            {
                Title = "Interstellar",
                Year = 2014,
                Rated = "PG-13",
                Runtime = "169 min",
                Genre = "Sci-Fi, Adventure, Drama",
                Plot = "A team of explorers travel through a wormhole in space in an attempt to ensure humanity's survival.",
                Poster = "https://m.media-amazon.com/images/M/MV5BZjdkOTU3MDktN2IxOS00OGEyLWFmMjktY2FiMmZkNWIyODZiXkEyXkFqcGdeQXVyMTMxODk2OTU@.jpg",
                ImdbRating = 8.6F,
                ScreenShot = "http://wp.production.patheos.com/blogs/watchinggod/files/2014/11/interstellar_poster_0.jpg",
            };
            context.Movies.Add(MovieModelDALMachine28);

            var MovieModelDALMachine29 = new MovieModelDAL
            {
                Title = "Reservoir Dogs",
                Year = 1992,
                Rated = "R",
                Runtime = "99 min",
                Genre = "Crime, Drama, Thriller",
                Plot = "After a simple jewelry heist goes terribly wrong, the surviving criminals begin to suspect that one of them is a police informant.",
                Poster = "https://m.media-amazon.com/images/M/MV5BZmExNmEwYWItYmQzOS00YjA5LTk2MjktZjEyZDE1Y2QxNjA1XkEyXkFqcGdeQXVyMTQxNzMzNDI@.jpg",
                ImdbRating = 8.3F,
                ScreenShot = "https://MovieModelDALdiners.files.wordpress.com/2015/03/mr-brown-mr-blonde-and-mr-blue-at-the-diner.jpg",
            };
            context.Movies.Add(MovieModelDALMachine29);

            var MovieModelDALMachine30 = new MovieModelDAL
            {
                Title = "Indiana Jones and the Last Crusade",
                Year = 1989,
                Rated = "PG-13",
                Runtime = "127 min",
                Genre = "Adventure, Action, Fantasy",
                Plot = "In 1938, after his father Professor Henry Jones, Sr. goes missing while pursuing the Holy Grail, Indiana Jones finds himself up against Adolf Hitler's Nazis again to stop them obtaining its powers.",
                Poster = "https://m.media-amazon.com/images/M/MV5BMjNkMzc2N2QtNjVlNS00ZTk5LTg0MTgtODY2MDAwNTMwZjBjXkEyXkFqcGdeQXVyNDk3NzU2MTQ@.jpg",
                ImdbRating = 8.3F,
                ScreenShot = "http://cdn.collider.com/wp-content/uploads/indiana-jones-and-the-last-crusade1.jpg",
            };
            context.Movies.Add(MovieModelDALMachine30);

            var MovieModelDALMachine31 = new MovieModelDAL
            {
                Title = "E.T. the Extra-Terrestrial",
                Year = 1982,
                Rated = "PG",
                Runtime = "115 min",
                Genre = "Family, Sci-Fi",
                Plot = "A troubled child summons the courage to help a friendly alien escape Earth and return to his home world.",
                Poster = "https://m.media-amazon.com/images/M/MV5BMTQ2ODFlMDAtNzdhOC00ZDYzLWE3YTMtNDU4ZGFmZmJmYTczXkEyXkFqcGdeQXVyMTQxNzMzNDI@.jpg",
                ImdbRating = 7.9F,
                ScreenShot = "https://madisonMovieModelDAL.files.wordpress.com/2016/10/et-extra-terrestrial.jpg?w=1024&h=624",
            };
            context.Movies.Add(MovieModelDALMachine31);

            var MovieModelDALMachine32 = new MovieModelDAL
            {
                Title = "Crazy, Stupid, Love.",
                Year = 2011,
                Rated = "PG-13",
                Runtime = "118 min",
                Genre = "Comedy, Drama, Romance",
                Plot = "A middle-aged husband's life changes dramatically when his wife asks him for a divorce. He seeks to rediscover his manhood with the help of a newfound friend, Jacob, learning to pick up girls at bars.",
                Poster = "https://m.media-amazon.com/images/M/MV5BMTg2MjkwMTM0NF5BMl5BanBnXkFtZTcwMzc4NDg2NQ@@.jpg",
                ImdbRating = 7.4F,
                ScreenShot = "https://i.ytimg.com/vi/9Ms1YK5cvi8/maxresdefault.jpg",
            };
            context.Movies.Add(MovieModelDALMachine32);

            var MovieModelDALMachine33 = new MovieModelDAL
            {
                Title = "The Bourne Ultimatum",
                Year = 2007,
                Rated = "PG-13",
                Runtime = "115 min",
                Genre = "Action, Mystery, Thriller",
                Plot = "Jason Bourne dodges a ruthless C.I.A. official and his Agents from a new assassination program while searching for the origins of his life as a trained killer.",
                Poster = "https://m.media-amazon.com/images/M/MV5BNGNiNmU2YTMtZmU4OS00MjM0LTlmYWUtMjVlYjAzYjE2N2RjXkEyXkFqcGdeQXVyNDk3NzU2MTQ@.jpg",
                ImdbRating = 8.0F,
                ScreenShot = "http://3.bp.blogspot.com/-gCCoM7EP_SM/VI5IGdGGCQI/AAAAAAAAM4E/xSaXslu7opY/s1600/The%2BBourne%2BUltimatum%2B2.jpg",
            };
            context.Movies.Add(MovieModelDALMachine33);

            var MovieModelDALMachine34 = new MovieModelDAL
            {
                Title = "Twelve Monkeys",
                Year = 1995,
                Rated = "R",
                Runtime = "129 min",
                Genre = "Sci-Fi, Mystery, Thriller",
                Plot = "In a future world devastated by disease, a convict is sent back in time to gather information about the man-made virus that wiped out most of the human population on the planet.",
                Poster = "https://m.media-amazon.com/images/M/MV5BN2Y2OWU4MWMtNmIyMy00YzMyLWI0Y2ItMTcyZDc3MTdmZDU4XkEyXkFqcGdeQXVyMTQxNzMzNDI@.jpg",
                ImdbRating = 8.0F,
                ScreenShot = "https://caragaleblog.files.wordpress.com/2015/07/12_monkeys_9.png",
            };
            context.Movies.Add(MovieModelDALMachine34);

            var MovieModelDALMachine35 = new MovieModelDAL
            {
                Title = "Saving Private Ryan",
                Year = 1998,
                Rated = "R",
                Runtime = "169 min",
                Genre = "Drama, War",
                Plot = "Following the Normandy Landings, a group of U.S. soldiers go behind enemy lines to retrieve a paratrooper whose brothers have been killed in action.",
                Poster = "https://m.media-amazon.com/images/M/MV5BZjhkMDM4MWItZTVjOC00ZDRhLThmYTAtM2I5NzBmNmNlMzI1XkEyXkFqcGdeQXVyNDYyMDk5MTU@.jpg",
                ImdbRating = 8.6F,
                ScreenShot = "https://i1.wp.com/doblu.com/wp-content/uploads/2018/04/savingprivateryan20th14642.jpg",
            };
            context.Movies.Add(MovieModelDALMachine35);

            var MovieModelDALMachine36 = new MovieModelDAL
            {
                Title = "Juno",
                Year = 2007,
                Rated = "PG-13",
                Runtime = "96 min",
                Genre = "Comedy, Drama",
                Plot = "Faced with an unplanned pregnancy, an offbeat young woman makes an unusual decision regarding her unborn child.",
                Poster = "https://m.media-amazon.com/images/M/MV5BMTIwMDgwODc5Nl5BMl5BanBnXkFtZTYwMjQzMDM4.jpg",
                ImdbRating = 7.5F,
                ScreenShot = "http://1.bp.blogspot.com/-x-NtC4BNJdM/UjV2SMQj4pI/AAAAAAAACWA/Dah3jCWGh0g/s1600/QmWSK6q6pg.jpg",
            };
            context.Movies.Add(MovieModelDALMachine36);

            var MovieModelDALMachine38 = new MovieModelDAL
            {
                Title = "La La Land",
                Year = 2016,
                Rated = "PG-13",
                Runtime = "128 min",
                Genre = "Comedy, Drama, Music",
                Plot = "While navigating their careers in Los Angeles, a pianist and an actress fall in love while attempting to reconcile their aspirations for the future.",
                Poster = "https://m.media-amazon.com/images/M/MV5BMzUzNDM2NzM2MV5BMl5BanBnXkFtZTgwNTM3NTg4OTE@.jpg",
                ImdbRating = 8.1F,
                ScreenShot = "http://telecine.img.estaticos.tv.br/ckeditor/2017/04/26/Imagem-1_La-La-Land.png",
            };
            context.Movies.Add(MovieModelDALMachine38);

            var MovieModelDALMachine39 = new MovieModelDAL
            {
                Title = "The Big Lebowski",
                Year = 1998,
                Rated = "R",
                Runtime = "117 min",
                Genre = "Comedy, Crime",
                Plot = "\"The Dude\" Lebowski, mistaken for a millionaire Lebowski, seeks restitution for his ruined rug and enlists his bowling buddies to help get it.",
                Poster = "https://m.media-amazon.com/images/M/MV5BZTFjMjBiYzItNzU5YS00MjdiLWJkOTktNDQ3MTE3ZjY2YTY5XkEyXkFqcGdeQXVyNDk3NzU2MTQ@.jpg",
                ImdbRating = 8.1F,
                ScreenShot = "https://coubsecure-s.akamaihd.net/get/b66/p/coub/simple/cw_timeline_pic/d2ae2597090/ef2d9106a8b25201a6965/big_1411093210_1393083868_image.jpg",
            };
            context.Movies.Add(MovieModelDALMachine39);

            var MovieModelDALMachine40 = new MovieModelDAL
            {
                Title = "The Mist",
                Year = 2007,
                Rated = "R",
                Runtime = "126 min",
                Genre = "Sci-Fi, Horror, Thriller",
                Plot = "A freak storm unleashes a species of bloodthirsty creatures on a small town, where a small band of citizens hole up in a supermarket and fight for their lives.",
                Poster = "https://m.media-amazon.com/images/M/MV5BMTU2NjQyNDY1Ml5BMl5BanBnXkFtZTcwMTk1MDU1MQ@@.jpg",
                ImdbRating = 7.2F,
                ScreenShot = "http://3.bp.blogspot.com/_74pU6eWmEHc/TOAI5p2LG-I/AAAAAAAABNE/lFYZjPutQTs/s1600/the-mist-screenshot-1.JPG",
            };
            context.Movies.Add(MovieModelDALMachine40);

            var MovieModelDALMachine41 = new MovieModelDAL
            {
                Title = "K-PAX",
                Year = 2001,
                Rated = "PG-13",
                Runtime = "120 min",
                Genre = "Sci-Fi, Drama",
                Plot = "PROT is a patient at a mental hospital who claims to be from a far away planet. His psychiatrist tries to help him, only to begin to doubt his own explanations.",
                Poster = "https://m.media-amazon.com/images/M/MV5BMjE5ZDVkNDAtMTJmYy00NzkzLTg2ZDUtOTZkOTU1ZDYwYTFhL2ltYWdlL2ltYWdlXkEyXkFqcGdeQXVyNDk3NzU2MTQ@.jpg",
                ImdbRating = 7.4F,
                ScreenShot = "https://www.filmweb.no/bilder/migration_catalog/article595860.ece/REPRESENTATIONS/w/Kevin%20Spacey%20og%20Jeff%20Bridges%20i%20K-PAX",
            };
            context.Movies.Add(MovieModelDALMachine41);

            var MovieModelDALMachine42 = new MovieModelDAL
            {
                Title = "Blade Runner",
                Year = 1982,
                Rated = "R",
                Runtime = "117 min",
                Genre = "Sci-Fi, Thriller",
                Plot = "A blade runner must pursue and terminate four replicants who stole a ship in space, and have returned to Earth to find their creator.",
                Poster = "https://m.media-amazon.com/images/M/MV5BNzQzMzJhZTEtOWM4NS00MTdhLTg0YjgtMjM4MDRkZjUwZDBlXkEyXkFqcGdeQXVyNjU0OTQ0OTY@.jpg",
                ImdbRating = 8.2F,
                ScreenShot = "https://pmcvariety.files.wordpress.com/2013/05/bladerunner_sequel.jpg?w=1000&h=563&crop=1",
            };
            context.Movies.Add(MovieModelDALMachine42);

            var MovieModelDALMachine43 = new MovieModelDAL
            {
                Title = "The Hangover",
                Year = 2009,
                Rated = "R",
                Runtime = "100 min",
                Genre = "Comedy",
                Plot = "Three buddies wake up from a bachelor party in Las Vegas, with no memory of the previous night and the bachelor missing. They make their way around the city in order to find their friend before his wedding.",
                Poster = "https://m.media-amazon.com/images/M/MV5BNGQwZjg5YmYtY2VkNC00NzliLTljYTctNzI5NmU3MjE2ODQzXkEyXkFqcGdeQXVyNzkwMjQ5NzM@.jpg",
                ImdbRating = 7.7F,
                ScreenShot = "http://www.cultjer.com/img/MovieModelDAL/thehangover_big.jpg",
            };
            context.Movies.Add(MovieModelDALMachine43);

            var MovieModelDALMachine44 = new MovieModelDAL
            {
                Title = "Back to the Future",
                Year = 1985,
                Rated = "PG",
                Runtime = "116 min",
                Genre = "Adventure, Comedy, Sci-Fi",
                Plot = "Marty McFly, a 17-year-old high school student, is accidentally sent thirty years into the past in a time-traveling DeLorean invented by his close friend, the maverick scientist Doc Brown.",
                Poster = "https://m.media-amazon.com/images/M/MV5BZmU0M2Y1OGUtZjIxNi00ZjBkLTg1MjgtOWIyNThiZWIwYjRiXkEyXkFqcGdeQXVyMTQxNzMzNDI@.jpg",
                ImdbRating = 8.5F,
                ScreenShot = "https://timedotcom.files.wordpress.com/2016/01/160128_em_delorean.jpg",
            };
            context.Movies.Add(MovieModelDALMachine44);

            var MovieModelDALMachine45 = new MovieModelDAL
            {
                Title = "The Grand Budapest Hotel",
                Year = 2014,
                Rated = "R",
                Runtime = "99 min",
                Genre = "Adventure, Comedy, Drama",
                Plot = "The adventures of Gustave H, a legendary concierge at a famous hotel from the fictional Republic of Zubrowka between the first and second World Wars, and Zero Moustafa, the lobby boy who becomes his most trusted friend.",
                Poster = "https://m.media-amazon.com/images/M/MV5BMzM5NjUxOTEyMl5BMl5BanBnXkFtZTgwNjEyMDM0MDE@.jpg",
                ImdbRating = 8.1F,
                ScreenShot = "https://imgs.gotrip.hk/wp-content/uploads/2016/08/b02-e1511193535797-1050x630.jpg",
            };
            context.Movies.Add(MovieModelDALMachine45);

            var MovieModelDALMachine46 = new MovieModelDAL
            {
                Title = "The Godfather",
                Year = 1972,
                Rated = "R",
                Runtime = "175 min",
                Genre = "Crime, Drama",
                Plot = "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son.",
                Poster = "https://m.media-amazon.com/images/M/MV5BM2MyNjYxNmUtYTAwNi00MTYxLWJmNWYtYzZlODY3ZTk3OTFlXkEyXkFqcGdeQXVyNzkwMjQ5NzM@.jpg",
                ImdbRating = 9.2F,
                ScreenShot = "https://www.slashfilm.com/wp/wp-content/images/Godfather-Still01.jpg",
            };

            context.Movies.Add(MovieModelDALMachine46);

            var MovieModelDALMachine47 = new MovieModelDAL
            {
                Title = "Casino Royale",
                Year = 2006,
                Rated = "PG-13",
                Runtime = "144 min",
                Genre = "Action, Adventure, Thriller",
                Plot = "Armed with a license to kill, Secret Agent James Bond sets out on his first mission as 007, and must defeat a private banker to terrorists in a high stakes game of poker at Casino Royale, Montenegro, but things are not what they seem.",
                Poster = "https://m.media-amazon.com/images/M/MV5BMDI5ZWJhOWItYTlhOC00YWNhLTlkNzctNDU5YTI1M2E1MWZhXkEyXkFqcGdeQXVyNTIzOTk5ODM@.jpg",
                ImdbRating = 8.0F,
                ScreenShot = "https://c.wallhere.com/photos/c4/66/1920x1080_px_Casino_Royale_Daniel_Craig_James_Bond_Movies-631960.jpg!d",
            };

            context.Movies.Add(MovieModelDALMachine47);

            var MovieModelDALMachine48 = new MovieModelDAL
            {
                Title = "The Wild Bunch",
                Year = 1969,
                Rated = "R",
                Runtime = "135 min",
                Genre = "Action, Adventure, Western",
                Plot = "An aging group of outlaws look for one last big score as the \"traditional\" American West is disappearing around them.",
                Poster = "https://m.media-amazon.com/images/M/MV5BNGUyYTZmOWItMDJhMi00N2IxLWIyNDMtNjUxM2ZiYmU5YWU1XkEyXkFqcGdeQXVyNjc1NTYyMjg@.jpg",
                ImdbRating = 8.0F,
                ScreenShot = "http://img.over-blog-kiwi.com/0/99/46/17/20150704/ob_e57cea_6-the-wild-bunch.jpg",
            };
            context.Movies.Add(MovieModelDALMachine48);

            var MovieModelDALMachine49 = new MovieModelDAL
            {
                Title = "Die Hard",
                Year = 1988,
                Rated = "R",
                Runtime = "132 min",
                Genre = "Action, Thriller",
                Plot = "John McClane, officer of the NYPD, tries to save his wife Holly Gennaro and several others that were taken hostage by German terrorist Hans Gruber during a Christmas party at the Nakatomi Plaza in Los Angeles.",
                Poster = "https://m.media-amazon.com/images/M/MV5BMzNmY2IwYzAtNDQ1NC00MmI4LThkOTgtZmVhYmExOTVhMWRkXkEyXkFqcGdeQXVyMTk5NDA3Nw@@.jpg",
                ImdbRating = 8.2F,
                ScreenShot = "http://1.bp.blogspot.com/-LEJtu4pKsNw/TnGI_oScWBI/AAAAAAAAD9k/C-ypKccvXIQ/s1600/DieHard_114Pyxurz.jpg",
            };
            context.Movies.Add(MovieModelDALMachine49);

            var MovieModelDALMachine50 = new MovieModelDAL
            {
                Title = "Trainspotting",
                Year = 1996,
                Rated = "R",
                Runtime = "94 min",
                Genre = "Drama",
                Plot = "Renton, deeply immersed in the Edinburgh drug scene, tries to clean up and get out, despite the allure of the drugs and influence of friends.",
                Poster = "https://m.media-amazon.com/images/M/MV5BMzA5Zjc3ZTMtMmU5YS00YTMwLWI4MWUtYTU0YTVmNjVmODZhXkEyXkFqcGdeQXVyNjU0OTQ0OTY@.jpg",
                ImdbRating = 8.2F,
                ScreenShot = "http://cdn.playbuzz.com/cdn/e6a80f25-87eb-4f6c-848c-d698bd09061c/9258ad7d-09b0-4121-9fcd-d921d415628d.jpg",
            };
            context.Movies.Add(MovieModelDALMachine50);

            var MovieModelDALMachine51 = new MovieModelDAL
            {
                Title = "The Meg",
                Year = 2018,
                Rated = "PG-13",
                Runtime = "113 min",
                Genre = "Action, Horror, Sci-Fi",
                Plot = "After escaping an attack by what he claims was a 70-foot shark, Jonas Taylor must confront his fears to save those trapped in a sunken submersible.",
                Poster = "https://m.media-amazon.com/images/M/MV5BMjg0MzA4MDE0N15BMl5BanBnXkFtZTgwMzk3MzAwNjM@.jpg",
                ImdbRating = 6.1F,
                ScreenShot = "https://bloody-disgusting.com/wp-content/uploads/2018/01/MEG-FP-0002.jpg",
            };
            context.Movies.Add(MovieModelDALMachine51);

            var MovieModelDALMachine52 = new MovieModelDAL
            {
                Title = "The Prestige",
                Year = 2006,
                Rated = "PG-13",
                Runtime = "130 min",
                Genre = "Drama, Mystery, Sci-Fi",
                Plot = "After a tragic accident, two stage magicians engage in a battle to create the ultimate illusion while sacrificing everything they have to outwit each other.",
                Poster = "https://m.media-amazon.com/images/M/MV5BMjA4NDI0MTIxNF5BMl5BanBnXkFtZTYwNTM0MzY2.jpg",
                ImdbRating = 8.5F,
                ScreenShot = "http://www.lebleudumiroir.fr/wp-content/uploads/2006/11/still_prestige.jpg",
            };
            context.Movies.Add(MovieModelDALMachine52);

            var MovieModelDALMachine53 = new MovieModelDAL
            {
                Title = "The Great Dictator",
                Year = 1940,
                Rated = "PASSED",
                Runtime = "125 min",
                Genre = "Comedy, Drama, War",
                Plot = "Dictator Adenoid Hynkel tries to expand his empire while a poor Jewish barber tries to avoid persecution from Hynkel's regime.",
                Poster = "https://m.media-amazon.com/images/M/MV5BMmExYWJjNTktNGUyZS00ODhmLTkxYzAtNWIzOGEyMGNiMmUwXkEyXkFqcGdeQXVyNjU0OTQ0OTY@.jpg",
                ImdbRating = 8.5F,
                ScreenShot = "http://www.west46thmag.com/wp-content/uploads/2016/01/The-Great-Dictator.png",
            };
            context.Movies.Add(MovieModelDALMachine53);

            var MovieModelDALMachine54 = new MovieModelDAL
            {
                Title = "Terminator 2",
                Year = 1991,
                Rated = "R",
                Runtime = "137 min",
                Genre = "Action, Sci-Fi",
                Plot = "A cyborg, identical to the one who failed to kill Sarah Connor, must now protect her teenage son, John Connor, from a more advanced and powerful cyborg.",
                Poster = "https://m.media-amazon.com/images/M/MV5BMGU2NzRmZjUtOGUxYS00ZjdjLWEwZWItY2NlM2JhNjkxNTFmXkEyXkFqcGdeQXVyNjU0OTQ0OTY@.jpg",
                ImdbRating = 8.5F,
                ScreenShot = "https://jdcdn-wabisabiinvestme.netdna-ssl.com/wp-content/uploads/2015/11/T2-por.jpg",
            };
            context.Movies.Add(MovieModelDALMachine54);

            var MovieModelDALMachine55 = new MovieModelDAL
            {
                Title = "Mission: Impossible - Ghost Protocol",
                Year = 2011,
                Rated = "PG-13",
                Runtime = "132 min",
                Genre = "Action, Adventure, Thriller",
                Plot = "The IMF is shut down when it's implicated in the bombing of the Kremlin, causing Ethan Hunt and his new team to go rogue to clear their organization's name.",
                Poster = "https://m.media-amazon.com/images/M/MV5BMTY4MTUxMjQ5OV5BMl5BanBnXkFtZTcwNTUyMzg5Ng@@.jpg",
                ImdbRating = 7.4F,
                ScreenShot = "https://images.alphacoders.com/782/thumb-1920-782258.jpg",
            };
            context.Movies.Add(MovieModelDALMachine55);

            var MovieModelDALMachine56 = new MovieModelDAL
            {
                Title = "2001: A Space Odyssey",
                Year = 1968,
                Rated = "G",
                Runtime = "149 min",
                Genre = "Sci-Fi, Adventure",
                Plot = "Humanity finds a mysterious, obviously artificial object buried beneath the Lunar surface and, with the intelligent computer HAL 9000, sets off on a quest.",
                Poster = "https://m.media-amazon.com/images/M/MV5BMmNlYzRiNDctZWNhMi00MzI4LThkZTctMTUzMmZkMmFmNThmXkEyXkFqcGdeQXVyNzkwMjQ5NzM@.jpg",
                ImdbRating = 8.3F,
                ScreenShot = "https://i.ytimg.com/vi/Z2UWOeBcsJI/maxresdefault.jpg ",
            };
            context.Movies.Add(MovieModelDALMachine56);

            var MovieModelDALMachine57 = new MovieModelDAL
            {
                Title = "Arrival",
                Year = 2016,
                Rated = "PG-13",
                Runtime = "116 min",
                Genre = "Sci-Fi, Drama, Mystery",
                Plot = "A linguist is recruited by the military to communicate with alien lifeforms after twelve mysterious spacecrafts land around the world.",
                Poster = "https://m.media-amazon.com/images/M/MV5BMTExMzU0ODcxNDheQTJeQWpwZ15BbWU4MDE1OTI4MzAy.jpg",
                ImdbRating = 7.9F,
                ScreenShot = "https://stmed.net/sites/default/files/arrival-wallpapers-29389-3213875.jpg",
            };
            context.Movies.Add(MovieModelDALMachine57);

            var MovieModelDALMachine58 = new MovieModelDAL
            {
                Title = "Shaun of the Dead",
                Year = 2004,
                Rated = "R",
                Runtime = "99 min",
                Genre = "Comedy, Horror",
                Plot = "A man decides to turn his moribund life around by winning back his ex-girlfriend, reconciling his relationship with his mother, and dealing with an entire community that has returned from the dead to eat the living.",
                Poster = "https://m.media-amazon.com/images/M/MV5BMTg5Mjk2NDMtZTk0Ny00YTQ0LWIzYWEtMWI5MGQ0Mjg1OTNkXkEyXkFqcGdeQXVyNzkwMjQ5NzM@.jpg",
                ImdbRating = 7.9F,
                ScreenShot = "https://vucscdnprodne.azureedge.net/images/vmest_prod/1/furniture/VX-5877274_1920x1080.PNG",
            };
            context.Movies.Add(MovieModelDALMachine58);


            context.Movies.Add(MovieModelDAL1);
            context.Movies.Add(film2);
            context.Movies.Add(newMovieModelDAL1);
            context.Movies.Add(newMovieModelDAL2);
            context.Movies.Add(newMovieModelDAL3);
            context.Movies.Add(newMovieModelDAL4);
            context.Movies.Add(newMovieModelDAL5);
            context.Movies.Add(newMovieModelDAL6);
            context.Movies.Add(newMovieModelDAL7);
            context.Movies.Add(newMovieModelDAL8);
            context.Movies.Add(newMovieModelDAL9);
            context.Movies.Add(newMovieModelDAL10);
            context.Movies.Add(newMovieModelDAL11);
            context.Movies.Add(newMovieModelDAL12);
            context.Movies.Add(newMovieModelDAL13);
            context.Movies.Add(newMovieModelDAL14);
            context.Movies.Add(newMovieModelDAL15);
            context.Movies.Add(newMovieModelDAL16);
            context.Movies.Add(newMovieModelDAL17);


            if (context.AdminUsers.Find("admin") == null)
            {

                var adminUser = new AdminUserModelDAL
                {
                    Username = "admin",
                    HashedPassword = PasswordHelperTool.PasswordSHA256Hasher("1234")
                };

                try
                {
                    context.AdminUsers.Add(adminUser);
                    base.Seed(context);
                }
                catch (Exception ex)
                {
                    var logg = new LoggTypeDAL()
                    {
                        EventType = "Exception",
                        Created_By = "System",
                        LogMessage = ex.ToString(),
                        Created_date = DateTime.Now
                    };
                    Loggings.LogToBoth(logg);
                }
            }


            var logg2 = new LoggTypeDAL()
            {
                EventType = "Event",
                Created_By = "System",
                LogMessage = "Seeded database with Movie Entries and default Admin Users",
                Created_date = DateTime.Now
            };
            Loggings.LogToBoth(logg2);

            var FAQ1 = new FAQModelDAL
            {
                Question = "What is the point of this website?",
                Answer = "It is a school project in a WebApplications class.",
                UserSubmitted = false,
                Score = 0
            };
            context.FAQs.Add(FAQ1);

            var FAQ2 = new FAQModelDAL
            {
                Question = "Which technology was used to make this website?",
                Answer = "Mainly .NET and MVC but also standard technologies such as HTML, CSS and JavaScript",
                UserSubmitted = false,
                Score = 0
            };
            context.FAQs.Add(FAQ2);

            var FAQ3 = new FAQModelDAL
            {
                Question = "Is this the entire website?",
                Answer = "The task includes this user website and an administration interface for administrators",
                UserSubmitted = false,
                Score = 0
            };
            context.FAQs.Add(FAQ3);

            var FAQ4 = new FAQModelDAL
            {
                Question = "How do I make an user?",
                Answer = "In the top right portion of the screen it should say 'sign up' if you have not signed up allready.",
                UserSubmitted = false,
                Score = 0
            };
            context.FAQs.Add(FAQ4);

            var FAQ5 = new FAQModelDAL
            {
                Question = "Why does every movie download some lecture video?",
                Answer = "",
                UserSubmitted = true,
                Score = 6
            };
            context.FAQs.Add(FAQ5);

            var FAQ6 = new FAQModelDAL
            {
                Question = "Why is the website called Nova?",
                Answer = "",
                UserSubmitted = true,
                Score = 4
            };
            context.FAQs.Add(FAQ6);

            var FAQ7 = new FAQModelDAL
            {
                Question = "Are these questions going to get an answer?",
                Answer = "",
                UserSubmitted = true,
                Score = 3
            };
            context.FAQs.Add(FAQ7);

            var FAQ8 = new FAQModelDAL
            {
                Question = "I forgot my password.",
                Answer = "",
                UserSubmitted = true,
                Score = 5
            };
            context.FAQs.Add(FAQ8);

            var FAQ9 = new FAQModelDAL
            {
                Question = "Will you make an app for this website?",
                Answer = "",
                UserSubmitted = true,
                Score = 1
            };
            context.FAQs.Add(FAQ9);


            base.Seed(context);
            
        }
    }
}