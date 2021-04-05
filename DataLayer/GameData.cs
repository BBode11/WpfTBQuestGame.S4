using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBQuestGame.Models;

namespace TBQuestGame.DataLayer
{
    public static class GameData
    {
        public static Player PlayerData()
        {
            return new Player()
            {
                ID = 1,
                Name = "Brandon",
                Age = 24,
                LocationId = 0,
                Health = 100,
                Lives = 3,
                Currency = 125,
                Inventory = new ObservableCollection<GameItem>()
                {
                    GameItemById(100)
                }
            };
        }
        /// <summary>
        /// Start up message, shows after filling out player setup
        /// </summary>
        /// <returns></returns>
        public static List<string> StartUpMessage()
        {
            return new List<string>()
            {
                "After getting laid off of work you decided you wanted to do some home improvements in your spare time." +
                "The only thing is you do not have all the tools and materials you need." +
                "You decided to go to the hardware store just down the road." +
                "You don't know it yet, but it is about to be the experience of your lifetime."
            };
        }
        /// <summary>
        /// Method to return a game item by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>GameItem</returns>
        private static GameItem GameItemById(int id)
        {
            return StandardGameItems().FirstOrDefault(i => i.Id == id);
        }

        private static Npc NpcById(int id)
        {
            return Npcs().FirstOrDefault(i => i.ID == id);
        }
        /// <summary>
        /// Map locations and descriptions
        /// </summary>
        /// <returns></returns>
        public static Map MapData()
        {
            //**** Possible Error
            Map gameMap = new Map();
            gameMap.StandardGameItems = StandardGameItems();

            return new Map()
            {
                MapLocations = new Location[]
                {
                    new Location()
                    {
                        Id = 0,
                        Name = "Isle 1",
                        Description = "(Treated Lumber) \n Down this isle you can find plywood, 2x4's and oriented strand board." ,
                        GameItems = new ObservableCollection<GameItem>
                        {
                            GameItemById(101),
                            GameItemById(201)
                        }

                    },

                    new Location()
                    {
                        Id = 1,
                        Name = "Isle 2",
                        Description = "(Non-Treated Lumber) \n Down this isle you can find plywood, 2x4's and oriented strand board. ",
                        GameItems = new ObservableCollection<GameItem>
                        {
                            GameItemById(202)
                        },
                        Npcs = new ObservableCollection<Npc>()
                        {
                            NpcById(402)
                        }
                    },

                    new Location()
                    {
                        Id = 2,
                        Name = "Isle 3",
                        Description = "(Saws) \n There are jig, circular, and miter saws down this isle. There also appears to be a worker stocking the shelves.",
                        GameItems = new ObservableCollection<GameItem>
                        {
                            GameItemById(203),
                            GameItemById(204)
                        }
                    },
                    new Location()
                    {
                        Id = 3,
                        Name = "Isle 4",
                        Description = "(Drills and Bits) \n There are many things down this isle including, cordless and regular drills, impact drivers, with many different bits." +
                        "The bits include a forstner, metal, and wood bits.",
                        Npcs = new ObservableCollection<Npc>()
                        {
                            NpcById(301)
                        }
                    },
                    new Location()
                    {
                        Id = 4,
                        Name = "Isle 5",
                        Description = "(Light Fixtures) \n Down this isle there are many things from LED lights to lava lamps. One of the lights appears to be broken.",
                        GameItems = new ObservableCollection<GameItem>
                        {
                            GameItemById(102)
                        }
                    },
                    new Location()
                    {
                        Id = 5,
                        Name = "Isle 6",
                        Description = "(Lawn and Outdoor) \n You are amazed when you go down this isle people are jousting on lawn mowers with weed whackers and you get hit by one of the rogue lawn mowers." +
                        "You lose half of your life and barely make it out of the isle alive. Hopefully you do not have to go back down there.",
                        ModifyHealth = 50

                    },
                    new Location()
                    {
                        Id = 6,
                        Name = "Isle 7",
                        Description = "(Outdoor Furniture / Grills) \n Wow you thought the last isle was weird. The townies are throwing their own BBQ in this isle and one of the townies asks if you brought a dish to pass.",
                        Npcs = new ObservableCollection<Npc>()
                        {
                            NpcById(302)
                        }
                    },
                    new Location()
                    {
                        Id = 7,
                        Name = "Isle 8",
                        Description = "(Gardening) \n The townies apparently left their means of transportation in this isle and there is random horses, goats, and pigs digging through the fertilizer.",
                        Npcs = new ObservableCollection<Npc>()
                        {
                            NpcById(401)
                        }
                    },
                    new Location()
                    {
                        Id = 8,
                        Name = "Isle 9",
                        Description = "(Nails and Screws) \n Down this isle you can find nothing but nails and screws of different assortments.",
                        GameItems = new ObservableCollection<GameItem>
                        {
                            GameItemById(103),
                            GameItemById(205),
                            GameItemById(206)
                        },
                        Npcs = new ObservableCollection<Npc>()
                        {
                            NpcById(303)
                        }
                    },
                    new Location()
                    {
                        Id = 9,
                        Name = "Isle 10",
                        Description = "(Paint and Stains) \n In this isle there is deck stain, outdoor paint and primer, polyurethane and indoor paint.",
                        GameItems = new ObservableCollection<GameItem>
                        {
                            GameItemById(207)
                        }
                    },
                    new Location()
                    {
                        Id = 10,
                        Name = "Checkout",
                        Description = "(Checkout) \n"
                    },
                },

                CurrentLocationId = 0,

            };
        }
        /// <summary>
        /// Game Items are added to list
        /// </summary>
        /// <returns></returns>
        public static List<GameItem> StandardGameItems()
        {
            return new List<GameItem>()
            {
                new Weapon(100, "Pocket Knife", 5, 15, "A shiny but very dull pocket knife. Mostly for looks."),
                new Weapon(101, "2x4 Board", 20, 35, "The 2x4 board is a very sturdy board that can make a great weapon in times of need."),
                new Weapon(102, "Lava Lamp", 0, 15, "The blue and green lava lamp will act as a blunt object to throw if you have good aim."),
                new Weapon(103, "Nail Gun", 40, 75, "The nail gun might be the best weapon you can find since it shoots 4 inch nails."),
                new Weapon(104, "Tire Iron", 15, 45, "The tire iron is a long blunt metal object and it can deal big amounts of damage."),
                new Weapon(105, "Yard Rake", 5, 15, "The yard rake is made of plastic and can deal little damage."),
                new Weapon(106, "Box Cutter", 5, 15, "An old and dull box cutter for opening boxes of product."),
                new BuildMaterial(201, 35, "Treated Plywood", "Treated plywood is used for many home projects because it is somewhat cheap and can be used for many things since it is treated."),
                new BuildMaterial(202, 25, "Non-Treated Plywood", "Similar to treated plywood it can also be used on many projects, but over time the plywood will split and warp."),
                new BuildMaterial(203, 60, "Circular Saw", "The circular saw is a very useful saw and can be used on many projects due to its versatility."),
                new BuildMaterial(204, 50, "JigSaw", "The jigsaw is a very useful saw for small cuts, but it might not be the best option for long cuts."),
                new BuildMaterial(205, 15, "Screws", "Screws are very useful for binding wood together."),
                new BuildMaterial(206, 5, "Nails", "Can be used to attach boards together, but they can loosen or warp over time."),
                new BuildMaterial(207, 15, "Indoor Paint", "This wood colored paint would look great on any home projects.")
            };
        }

        public static List<Npc> Npcs()
        {
            return new List<Npc>()
            {
               new Townie()
               {
                   ID = 301,
                   Name = "Townie Dale",
                   Description = "A tall man with a rather large beer belly. He appears to be disgruntled.",
                   Messages = new List<string>()
                   {
                       "You don't look like you are from around here.",
                       "I don't take too kind to strangers."
                   },
                   CurrentWeapon = GameItemById(105) as Weapon
               },
               new Townie()
               {
                   ID = 302,
                   Name = "Townie Plankton",
                   Description = "A vertically impaired man with rage in his eyes.",
                   Messages = new List<string>()
                   {
                       "You better leave this store before I make you.",
                       "There isn't room for you here.",
                       "Seems like you are looking for a fight."
                   },
                   CurrentWeapon = GameItemById(104) as Weapon
               },
               new Townie()
               {
                   ID = 303,
                   Name = "Townie Bruce",
                   Description = "A large old man who seems to be somewhat kind and lazy.",
                   Messages = new List<string>()
                   {
                       "There are so many sales going on today.",
                       "These sales bring in some weird towns people."
                   },
                   CurrentWeapon = GameItemById(106) as Weapon
               },
               new Worker()
               {
                   ID = 401,
                   Name = "Shelf Stocker Jerry",
                   Description = "An old guy large in height who seems oblivious to his surroundings.",
                   Messages = new List<string>()
                   {
                       "Hello, I am Jerry and I am restocking the shelfs!",
                       "We have some good sales today!",
                       "You are not a normal customer here."
                   }
               },
               new Worker()
               {
                   ID = 402,
                   Name = "Tina",
                   Description = "A new young worker who is texting more than working.",
                   Messages = new List<string>()
                   {
                       "This place is dumb",
                       "Do you mind I am trying to talk to my friends.",
                       "Ughh I hate talking to customers."
                   }
               }

            };
        }
    }
}

