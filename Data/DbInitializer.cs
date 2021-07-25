using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BooksStore.Models;

namespace BooksStore.Data
{
    public static class DbInitializer
    {
        public static void Initialize(BooksStoreContext context)
        {
            var users = new User[]
                {
                    new User{Username="admin",Password="admin",Address="Dizengoff Street 18",IsAdmin=true,Gender=false}
                };


            var branches = new Branch[]
            {
                 new Branch{BranchName="Ashdod Branch",City="Ashdod",Address="Rogozin St. 23, Ashdod",Latitude=31.804,Longitude=34.643, PhoneNumber="088663333"},
                 new Branch{BranchName="Tel Aviv Branch",City="Tel Aviv",Address="Dizengoff St. 18, Tel Aviv",Latitude=32.074,Longitude=34.779, PhoneNumber="036333333"},
                 new Branch{BranchName="Petah Tikva Branch",City="Petah Tikva",Address="Rotchild St. 76, Petah Tikva",Latitude=32.087,Longitude=34.883,PhoneNumber="036333332"},
                 new Branch{BranchName="Ramat Gan Branch",City="Ramat Gan",Address="Arlozorov St. 186, Ramat Gan",Latitude=32.082,Longitude=34.792,PhoneNumber="036333331"},
                 new Branch{BranchName="Bnei Brak Branch",City="Bnei Brak",Address="Rabi Akiva St. 89, Bnei Brak",Latitude=32.086,Longitude=34.832,PhoneNumber="03723161"}
            };

            var genres = new Genre[]
            {
                new Genre{GenreName = "Fiction"},
                new Genre{GenreName = "Novel"},
                new Genre{GenreName = "Fantasy"},
                new Genre{GenreName = "Thriller"},
                new Genre{GenreName = "History"}
            };


            var books = new Book[]
            {
                new Book{BookName = "Grant", Author="J.R.R Tolkien", Publication="Zmora Bitan", Price = 90, Summary = "Pulitzer Prize winner Ron Chernow returns with a sweeping and dramatic portrait of one of our most compelling generals and presidents, Ulysses S. Grant. With lucidity, breadth, and meticulousness, Chernow finds the threads that bind Grant's disparate stories together, shedding new light on the man whom Walt Whitman described as 'nothing heroic...and yet the greatest hero.'", PictureName = "/img/Grant.jpg", Genre = genres[4]},
                new Book{BookName = "The History of the Ancient World", Author="Isabella Maldonado", Publication="Modan", Price = 88, Summary = "A lively and engaging narrative history showing the common threads in the cultures that gave birth to our own. Dozens of maps provide a clear geography of great events, while timelines give the reader an ongoing sense of the passage of years and cultural interconnection. Literature, epic traditions, private letters and accounts connect kings and leaders with the lives of those they ruled.", PictureName = "/img/TheHistoryOfAncientWorld.jpg", Genre = genres[4]},
                new Book{BookName = "Churchill: Walking with Destiny", Author="Andrew Roberts", Publication="Kineret", Price = 100, Summary = "We think of Churchill as a hero who saved civilization from the evils of Nazism and warned of the grave crimes of Soviet communism, but Roberts's masterwork reveals that he has as much to teach us about the challenges leaders face today - and the fundamental values of courage, tenacity, leadership and moral conviction.", PictureName = "/img/Churchill.jpg", Genre = genres[4]},

                new Book{BookName = "The Cipher", Author="Susan Wise Bauer", Publication="Kineret", Price = 150, Summary = "FBI Special Agent Nina Guerrera escaped a serial killer’s trap at sixteen. Years later, when she’s jumped in a Virginia park, a video of the attack goes viral. Legions of new fans are not the only ones impressed with her fighting skills. The man who abducted her eleven years ago is watching. Determined to reclaim his lost prize, he commits a grisly murder designed to pull her into the investigation…but his games are just beginning. And he’s using the internet to invite the public to play along", PictureName = "/img/TheCipher.jpg", Genre = genres[3] },
                //new Book{ },
                //new Book{ },

                new Book{BookName = "The Hobbit", Author="Ron Chernow", Publication="Modan", Price = 40, Summary = "Bilbo Baggins lives a quiet, peaceful life in his comfortable hole at Bag End. Bilbo lives in a hole because he is a hobbit—one of a race of small..", PictureName ="/img/TheHobbit.png", Genre = genres[2] },
                //new Book{ },
                //new Book{ },

                new Book{BookName = "The Kite Runner", Author="Khaled Hosseini", Publication="Zmora Bitan", Price = 95, Summary = "Told against the backdrop of the changing political landscape of Afghanistan from the 1970s to the period following 9/11, The Kite Runner is the story of the unlikely and complicated friendship between Amir, the son of a wealthy merchant, and Hassan, the son of his father’s servant until cultural and class differences and the turmoil of war tear them asunder. Hosseini brings his homeland to life for us in a way that post 9/11 media coverage never could, showing us a world of ordinary people who live, die, eat, pray, dream, and love. It’s a story about the long shadows that family secrets cast across decades, the enduring love of friendship, and the transformative power of forgiveness.", PictureName = "/img/TheKiteRunner.jpg", Genre = genres[1] },

                new Book{BookName = "The Handmaid's Tale", Author="Margaret Eleanor Atwood", Publication="Yediot", Price = 78, Summary = "Everything Handmaids wear is red: the colour of blood, which defines us. Offred is a Handmaid in the Republic of Gilead, where women are prohibited from holding jobs, reading, and forming friendships. She serves in the household of the Commander and his wife, and under the new social order she has only one purpose: once a month, she must lie on her back and pray that the Commander makes her pregnant, ecause in an age of declining births, Offred and the other Handmaids are valued only if they are fertile. But Offred remembers the years before Gilead, when she was an independent woman who had a job, a family, and a name of her own. Now, her memories and her will to survive are acts of rebellion", PictureName = "/img/TheHandmaid.jpg", Genre = genres[0]},
                new Book{BookName = "Transcendent Kingdom", Author="Yaa Gyasi", Publication=" Knopf", Price = 90, Summary = "From the author of Homegoing, the breakout debut novel about the two very different legacies of an Asante woman living in 18th-century Ghana, comes a contemporary tale of a Ghanaian family in Alabama struggling to make sense of loss. ", PictureName = "/img/TranscendentKngdom.jpg", Genre = genres[1]},
                new Book{BookName = "The Woods", Author="Harlan Coben", Publication="Dutton", Price = 100, Summary = "Paul Copeland, a New Jersey county prosecutor, is still grieving the loss of his sister twenty years ago—the night she walked into the woods, never to be seen again. But now, a homicide victim is found with evidence linking him to the disappearance. The victim could be the boy who vanished along with Paul's sister. And, as hope rises that his sister could still be alive, dangerous secrets from his family's past threaten to tear apart everything Paul has been trying to hold together...", PictureName = "/img/TheWoods.jpg", Genre = genres[3]},
                new Book{BookName = "The Catcher in the Rye", Author=" J. D. Salinger", Publication="Little, Brown and Company", Price = 85, Summary = "The hero-narrator of The Catcher in the Rye is an ancient child of sixteen, a native New Yorker named Holden Caulfield. Through circumstances that tend to preclude adult, secondhand description, he leaves his prep school in Pennsylvania and goes underground in New York City for three days. The boy himself is at once too simple and too complex for us to make any final comment about him or his story. Perhaps the safest thing we can say about Holden is that he was born in the world not just strongly attracted to beauty but, almost, hopelessly impaled on it. There are many voices in this novel: children's voices, adult voices, underground voices-but Holden's voice is the most eloquent of all. Transcending his own vernacular, yet remaining marvelously faithful to it, he issues a perfectly articulated cry of mixed pain and pleasure. However, like most lovers and clowns and poets of the higher orders, he keeps most of the pain to, and for, himself. The pleasure he gives away, or sets aside, with all his heart. It is there for the reader who can handle it to keep.", PictureName = "/img/TheCatcherintheRye.jpg", Genre = genres[1]},
                new Book{BookName = "Anna Karenina", Author="Leo Tolstoy", Publication="Penguin Classics ", Price = 85, Summary = "Described by William Faulkner as the best novel ever written and by Fyodor Dostoevsky as “flawless,” Anna Karenina tells of the doomed love affair between the sensuous and rebellious Anna and the dashing officer, Count Vronsky. Tragedy unfolds as Anna rejects her passionless marriage and thereby exposes herself to the hypocrisies of society. Set against a vast and richly textured canvas of nineteenth-century Russia, the novel's seven major characters create a dynamic imbalance, playing out the contrasts of city and country life and all the variations on love and family happiness", PictureName = "/img/AnnaKarenina.jpg", Genre = genres[1]},
                new Book{BookName = "To Kill a Mockingbird", Author="Harper Lee", Publication="Harper Perennial", Price = 94, Summary = "One of the most cherished stories of all time, To Kill a Mockingbird has been translated into more than forty languages, sold more than forty million copies worldwide, served as the basis for an enormously popular motion picture, and was voted one of the best novels of the twentieth century by librarians across the country. A gripping, heart-wrenching, and wholly remarkable tale of coming-of-age in a South poisoned by virulent prejudice, it views a world of great beauty and savage inequities through the eyes of a young girl, as her father—a crusading local lawyer—risks everything to defend a black man unjustly accused of a terrible crime.", PictureName = "/img/ToKillaMockingbird.jpg", Genre = genres[1]},
                new Book{BookName = "The Great Gatsby", Author="F. Scott Fitzgerald", Publication="Francis Scott Fitzgerald", Price = 85, Summary = "The Great Gatsby, F. Scott Fitzgerald's third book, stands as the supreme achievement of his career. This exemplary novel of the Jazz Age has been acclaimed by generations of readers. The story is of the fabulously wealthy Jay Gatsby and his new love for the beautiful Daisy Buchanan, of lavish parties on Long Island at a time when The New York Times noted 'gin was the national drink and sex the national obsession,' it is an exquisitely crafted tale of America in the 1920s.", PictureName = "/img/TheGreatGatsby.jpg", Genre = genres[1]},
                new Book{BookName = "One Hundred Years of Solitude", Author="Gabriel Garcia Marquez", Publication="Harper Perennial Modern Classics", Price = 80, Summary = "One Hundred Years of Solitude is the first piece of literature since the Book of Genesis that should be required reading for the entire human race....Mr. Garcia Marquez has done nothing less than to create in the reader a sense of all that is profound, meaningful, and meaningless in life", PictureName = "/img/OneHundredYearsofSolitude.jpg", Genre = genres[1]},
                new Book{BookName = "Don Quixote", Author="Miguel De Cervantes Saavedra", Publication="Penguin Classics", Price = 85, Summary = "Don Quixote has become so entranced reading tales of chivalry that he decides to turn knight errant himself. In the company of his faithful squire, Sancho Panza, these exploits blossom in all sorts of wonderful ways. While Quixote's fancy often leads him astray—he tilts at windmills, imagining them to be giants—Sancho acquires cunning and a certain sagacity. Sane madman and wise fool, they roam the world together-and together they have haunted readers' imaginations for nearly four hundred years.", PictureName = "/img/DonQuixote.jpg", Genre = genres[1]},
                new Book{BookName = "Jane Eyre: An Autobiography", Author="Charlotte Bronte", Publication="Wentworth Press", Price = 96, Summary = "This work has been selected by scholars as being culturally important, and is part of the knowledge base of civilization as we know it. This work was reproduced from the original artifact, and remains as true to the original work as possible. Therefore, you will see the original copyright references, library stamps (as most of these works have been housed in our most important libraries around the world), and other notations in the work.", PictureName = "/img/JaneEyre.jpg", Genre = genres[1]},
                new Book{BookName = "The Immortality Key", Author="Brian C. Muraresku", Publication="St. Martin's Press", Price = 80, Summary = "The most influential religious historian of the 20th century, Huston Smith, once referred to it as the 'best-kept secret' in history. Did the Ancient Greeks use drugs to find God? And did the earliest Christians inherit the same, secret tradition? A profound knowledge of visionary plants, herbs and fungi passed from one generation to the next, ever since the Stone Age?", PictureName = "/img/TheImmortalityKey.jpg", Genre = genres[4]},
                new Book{BookName = "War and Genocide: A Concise History of the Holocaust", Author="Doris L. Bergen", Publication="Rowman & Littlefield Publishers", Price = 85, Summary = "In examining one of the defining events of the twentieth century, Doris L. Bergen situates the Holocaust in its historical, political, social, cultural, and military contexts. Unlike many other treatments of the Holocaust, this revised, third edition discusses not only the persecution of the Jews, but also other segments of society victimized by the Nazis: Roma, homosexuals, Poles, Soviet POWs, the disabled, and other groups deemed undesirable. In clear and eloquent prose, Bergen explores the two interconnected goals that drove the Nazi German program of conquest and genocide—purification of the so-called Aryan race and expansion of its living space—and discusses how these goals affected the course of World War II. Including firsthand accounts from perpetrators, victims, and eyewitnesses, her book is immediate, human, and eminently readable.", PictureName = "/img/WarandGenocide.jpg", Genre = genres[4]},
                new Book{BookName = "Why?: Explaining the Holocaust", Author="Peter Hayes", Publication="W. W. Norton & Company", Price = 90, Summary = "Why? explores one of the most tragic events in human history by addressing eight of the most commonly asked questions about the Holocaust: Why the Jews? Why the Germans? Why murder? Why this swift and sweeping? Why didn’t more Jews fight back more often? Why did survival rates diverge? Why such limited help from outside? What legacies, what lessons? An internationally acclaimed scholar, Peter Hayes brings a wealth of research and experience to bear on conventional views of the Holocaust, dispelling many misconceptions and challenging some of the most prominent recent interpretations", PictureName = "/img/Why.jpg", Genre = genres[4]},
                new Book{BookName = "The Housekeeper", Author="Natalie Barelli", Publication="Furphies Press", Price = 85, Summary = "When Claire sees Hannah Wilson at an exclusive Manhattan hair salon, it's like a knife slicing through barely healed scars. It may have been ten years since Claire last saw Hannah, but she has thought of her every day, and not in a good way. So Claire does what anyone would do in her position—she stalks her.", PictureName = "/img/TheHousekeeper.jpg", Genre = genres[3]},
                new Book{BookName = "I Am Watching You", Author="Teresa Driscoll", Publication="Thomas & Mercer", Price = 85, Summary = "When Ella Longfield overhears two attractive young men flirting with teenage girls on a train, she thinks nothing of it—until she realises they are fresh out of prison and her maternal instinct is put on high alert. But just as she’s decided to call for help, something stops her. The next day, she wakes up to the news that one of the girls—beautiful, green-eyed Anna Ballard—has disappeared.", PictureName = "/img/IAmWatchingYou.jpg", Genre = genres[3]},
                new Book{BookName = "Lethal Defense", Author="Michael Stagg", Publication="Nate Shepherd", Price = 85, Summary = "Attorney Nate Shepherd left a big firm to go out on his own. He sees nothing but opportunity when an out-of-town lawyer wants to hire him as local counsel on a high-profile murder case. Though his family worries that the case hits too close to home, Nate joins the defense team...", PictureName = "/img/LethalDefense.jpg", Genre = genres[3]},
                new Book{BookName = "Deadlock", Author="Catherine Coulter", Publication="Gallery Books", Price = 85, Summary = "A young wife is forced to confront a decades-old deadly secret when a medium connects her to her dead grandfather. A vicious psychopath wants ultimate revenge against Savich, but first, she wants to destroy what he loves most—his family.", PictureName = "/img/Deadlock.jpg", Genre = genres[3]},
                new Book{BookName = "Harry Potter and the Sorcerer's Stone", Author=" J.K. Rowling", Publication="Pottermore Publishing", Price = 85, Summary = "A global phenomenon and cornerstone of contemporary children’s literature, J.K. Rowling’s Harry Potter series is both universally adored and critically acclaimed. Now, experience the magic as you’ve never heard it before. The inimitable Jim Dale brings to life an entire cast of characters—from the pinched, nasal whine of Petunia Dursley to the shrill huff of the Sorting Hat to the earnest, wondrous voice of the boy wizard himself.", PictureName = "/img/HarryPotter.jpg", Genre = genres[2]},
                new Book{BookName = "Harry Potter and the Chamber of Secrets", Author="J.K. Rowling", Publication="Pottermore Publishing", Price = 85, Summary = "Harry Potter's summer has included the worst birthday ever, doomy warnings from a house-elf called Dobby, and rescue from the Dursleys by his friend Ron Weasley in a magical flying car! Back at Hogwarts School of Witchcraft and Wizardry for his second year, Harry hears strange whispers echo through empty corridors - and then the attacks start. Students are found as though turned to stone... Dobby's sinister predictions seem to be coming true.", PictureName = "/img/ChamberOfSecrets.jpg", Genre = genres[2]},
                new Book{BookName = "Harry Potter and the Order of the Phoenix", Author="J.K. Rowling", Publication="Pottermore Publishing", Price = 85, Summary = "Dark times have come to Hogwarts. After the Dementors' attack on his cousin Dudley, Harry Potter knows that Voldemort will stop at nothing to find him. There are many who deny the Dark Lord's return, but Harry is not alone: a secret order gathers at Grimmauld Place to fight against the dark forces. Harry must allow Professor Snape to teach him how to protect himself from Voldemort's savage assaults on his mind. But they are growing stronger by the day and Harry is running out of time....", PictureName = "/img/HPPhoenix.jpg", Genre = genres[2]},
                new Book{BookName = "Harry Potter and the Prisoner of Azkaban", Author="J.K. Rowling", Publication="Pottermore Publishing", Price = 85, Summary = "When the Knight Bus crashes through the darkness and screeches to a halt in front of him, it's the start of another far from ordinary year at Hogwarts for Harry Potter. Sirius Black, escaped mass-murderer and follower of Lord Voldemort, is on the run - and they say he is coming after Harry. In his first ever Divination class, Professor Trelawney sees an omen of death in Harry's tea leaves.... But perhaps most terrifying of all are the Dementors patrolling the school grounds, with their soul-sucking kiss.... ", PictureName = "/img/HPPrisoner.jpg", Genre = genres[2]},
                new Book{BookName = "A Game of Thrones: A Song of Ice and Fire", Author="George R. R. Martin", Publication="Bantam", Price = 85, Summary = "Winter is coming. Such is the stern motto of House Stark, the northernmost of the fiefdoms that owe allegiance to King Robert Baratheon in far-off King's Landing. There Eddard Stark of Winterfell rules in Robert's name. There his family dwells in peace and comfort: his proud wife, Catelyn; his sons Robb, Brandon, and Rickon; his daughters Sansa and Arya; and his bastard son, Jon Snow. Far to the north, behind the towering Wall, lie savage Wildings and worse - unnatural things relegated to myth during the centuries-long summer, but proving all too real and all too deadly in the turning of the season. Yet a more immediate threat lurks to the south, where Jon Arryn, the Hand of the King, has died under mysterious circumstances. Now Robert is riding north to Winterfell, bringing his queen, the lovely but cold Cersei, his son, the cruel, vainglorious Prince Joffrey, and the queen's brothers Jaime and Tyrion of the powerful and wealthy House Lannister - the first a swordsman without equal, the second a dwarf whose stunted stature belies a brilliant mind. ", PictureName = "/img/GamesOfThrones1.jpg", Genre = genres[2]},
                new Book{BookName = "A Dance with Dragons: A Song of Ice and Fire", Author="George R. R. Martin", Publication="Bantam", Price = 85, Summary = "Dubbed the American Tolkien by Time magazine, George R. R. Martin has earned international acclaim for his monumental cycle of epic fantasy. Now the number-one New York Times best-selling author delivers the fifth book in his spellbinding landmark series - as both familiar faces and surprising new forces vie for a foothold in a fragmented empire. ", PictureName = "/img/ADanceWithDragons.jpg", Genre = genres[2]},
                new Book{BookName = "A Clash of Kings: The Illustrated Edition", Author="George R. R. Martin", Publication="Bantam", Price = 85, Summary = "Time is out of joint. The summer of peace and plenty, ten years long, is drawing to a close, and the harsh, chill winter approaches like an angry beast. Two great leaders—Lord Eddard Stark and Robert Baratheon—who held sway over an age of enforced peace are dead . . . victims of royal treachery. Now, from the ancient citadel of Dragonstone to the forbidding shores of Winterfell, chaos reigns, as pretenders to the Iron Throne of the Seven Kingdoms prepare to stake their claims through tempest, turmoil, and war.", PictureName = "/img/AClashOfKings.jpg", Genre = genres[2]}
                
               // new Book{ }
            };

            var orders = new Order[]
            {
                new Order{DateTime = new DateTime(2020,10,05) ,FirstName = "Shaul", LastName = "Shauli", City = "Ramat Gan", Address = "7 Krinitzy st. Ramat Gan", Country = "Israel", PhoneNumber = "0544444444", Branch = branches[3], Book = books[0]},
                new Order{DateTime = new DateTime(2020,10,05) ,FirstName = "Shaul", LastName = "Shauli", City = "Tel Aviv", Address = "7 Krinitzy st. Tel Aviv", Country = "Israel", PhoneNumber = "0544444444", Branch = branches[1], Book = books[1]},
                new Order{DateTime = new DateTime(2020,10,05) ,FirstName = "Shaul", LastName = "Shauli", City = "Ashdod", Address = "7 Krinitzy st. Ashdod", Country = "Israel", PhoneNumber = "0544444444", Branch = branches[0], Book = books[1]},
                new Order{DateTime = new DateTime(2020,10,05) ,FirstName = "Shaul", LastName = "Shauli", City = "Ramat Gan", Address = "7 Krinitzy st. Bnei Brak", Country = "Israel", PhoneNumber = "0544444444", Branch = branches[4], Book = books[2]},
                new Order{DateTime = new DateTime(2020,10,05) ,FirstName = "Shaul", LastName = "Shauli", City = "Petach Tikva", Address = "7 Krinitzy st.Petach Tikva", Country = "Israel", PhoneNumber = "0544444444", Branch = branches[2], Book = books[3]},
                new Order{DateTime = new DateTime(2020,10,05) ,FirstName = "Shaul", LastName = "Shauli", City = "Ashdod", Address = "7 Krinitzy st. Ashdod", Country = "Israel", PhoneNumber = "0544444444", Branch = branches[0], Book = books[0]},
                new Order{DateTime = new DateTime(2020,10,05) ,FirstName = "Shaul", LastName = "Shauli", City = "Tel Aviv", Address = "7 Krinitzy st. Tel Aviv", Country = "Israel", PhoneNumber = "0544444444", Branch = branches[1], Book = books[15]},
                new Order{DateTime = new DateTime(2020,10,05) ,FirstName = "Shaul", LastName = "Shauli", City = "Tel Aviv", Address = "7 Krinitzy st. Tel Aviv", Country = "Israel", PhoneNumber = "0544444444", Branch = branches[1], Book = books[15]},
                new Order{DateTime = new DateTime(2020,10,05) ,FirstName = "Shaul", LastName = "Shauli", City = "Tel Aviv", Address = "7 Krinitzy st. Tel Aviv", Country = "Israel", PhoneNumber = "0544444444", Branch = branches[1], Book = books[6]},
                new Order{DateTime = new DateTime(2020,10,05) ,FirstName = "Shaul", LastName = "Shauli", City = "Tel Aviv", Address = "7 Krinitzy st. Tel Aviv", Country = "Israel", PhoneNumber = "0544444444", Branch = branches[1], Book = books[7]},
                new Order{DateTime = new DateTime(2020,10,05) ,FirstName = "Shaul", LastName = "Shauli", City = "Tel Aviv", Address = "7 Krinitzy st. Tel Aviv", Country = "Israel", PhoneNumber = "0544444444", Branch = branches[1], Book = books[7]},
                new Order{DateTime = new DateTime(2020,10,05) ,FirstName = "Shaul", LastName = "Shauli", City = "Tel Aviv", Address = "7 Krinitzy st. Tel Aviv", Country = "Israel", PhoneNumber = "0544444444", Branch = branches[1], Book = books[5]},
                new Order{DateTime = new DateTime(2020,10,05) ,FirstName = "Shaul", LastName = "Shauli", City = "Tel Aviv", Address = "7 Krinitzy st. Tel Aviv", Country = "Israel", PhoneNumber = "0544444444", Branch = branches[1], Book = books[11]},
                new Order{DateTime = new DateTime(2020,10,05) ,FirstName = "Shaul", LastName = "Shauli", City = "Tel Aviv", Address = "7 Krinitzy st. Tel Aviv", Country = "Israel", PhoneNumber = "0544444444", Branch = branches[1], Book = books[10]},
                new Order{DateTime = new DateTime(2020,10,05) ,FirstName = "Shaul", LastName = "Shauli", City = "Tel Aviv", Address = "7 Krinitzy st. Tel Aviv", Country = "Israel", PhoneNumber = "0544444444", Branch = branches[1], Book = books[10]},
                new Order{DateTime = new DateTime(2020,10,05) ,FirstName = "Shaul", LastName = "Shauli", City = "Tel Aviv", Address = "7 Krinitzy st. Tel Aviv", Country = "Israel", PhoneNumber = "0544444444", Branch = branches[1], Book = books[1]},
                new Order{DateTime = new DateTime(2020,10,05) ,FirstName = "Shaul", LastName = "Shauli", City = "Tel Aviv", Address = "7 Krinitzy st. Tel Aviv", Country = "Israel", PhoneNumber = "0544444444", Branch = branches[1], Book = books[13]},
                new Order{DateTime = new DateTime(2020,10,05) ,FirstName = "Shaul", LastName = "Shauli", City = "Tel Aviv", Address = "7 Krinitzy st. Tel Aviv", Country = "Israel", PhoneNumber = "0544444444", Branch = branches[1], Book = books[8]},
                new Order{DateTime = new DateTime(2020,10,05) ,FirstName = "Shaul", LastName = "Shauli", City = "Tel Aviv", Address = "7 Krinitzy st. Tel Aviv", Country = "Israel", PhoneNumber = "0544444444", Branch = branches[1], Book = books[8]},
                new Order{DateTime = new DateTime(2020,10,05) ,FirstName = "Shaul", LastName = "Shauli", City = "Tel Aviv", Address = "7 Krinitzy st. Tel Aviv", Country = "Israel", PhoneNumber = "0544444444", Branch = branches[1], Book = books[8]},
                new Order{DateTime = new DateTime(2020,10,05) ,FirstName = "Shaul", LastName = "Shauli", City = "Tel Aviv", Address = "7 Krinitzy st. Tel Aviv", Country = "Israel", PhoneNumber = "0544444444", Branch = branches[1], Book = books[10]},
                new Order{DateTime = new DateTime(2020,10,05) ,FirstName = "Shaul", LastName = "Shauli", City = "Tel Aviv", Address = "7 Krinitzy st. Tel Aviv", Country = "Israel", PhoneNumber = "0544444444", Branch = branches[1], Book = books[14]}
            };


            // Need to be fixed
            var orderDetails = new OrderDetail[]
            {
                new OrderDetail{OrderId = 1, BookId = 25,BookRating = 5, BookName = "Grant" ,UserId = "763ec680-52e9-42be-8f8e-329e628c4144",Price = 90, Quantity=1 },
                new OrderDetail{OrderId = 2, BookId = 26, BookRating = 5,BookName = "The History of the Ancient World",UserId = "763ec680-52e9-42be-8f8e-329e628c4144" ,Price = 88, Quantity=1 },
                new OrderDetail{OrderId = 3, BookId = 26,BookRating = 5,BookName = "The History of the Ancient World" , UserId = "763ec680-52e9-42be-8f8e-329e628c4144" ,Price = 88,Quantity=1 },
                new OrderDetail{OrderId = 4, BookId = 27,BookRating = 5,BookName = "Churchill: Walking with Destiny", UserId = "763ec680-52e9-42be-8f8e-329e628c4144",Price = 100, Quantity=1 },
                new OrderDetail{OrderId = 5, BookId = 28,BookRating = 5,BookName = "The Cipher", UserId = "763ec680-52e9-42be-8f8e-329e628c4144",Price = 150, Quantity=1 },
                new OrderDetail{OrderId = 6, BookId = 25,BookRating = 5,BookName = "Grant", UserId = "763ec680-52e9-42be-8f8e-329e628c4144",Price = 90,Quantity=1 },
                new OrderDetail{OrderId = 7, BookId = 14,BookRating = 5, BookName = "Jane Eyre: An Autobiography" , UserId = "763ec680-52e9-42be-8f8e-329e628c4144",Price = 96, Quantity=1 },
                new OrderDetail{OrderId = 8, BookId = 14,BookRating = 5,BookName = "Jane Eyre: An Autobiography",UserId = "763ec680-52e9-42be-8f8e-329e628c4144",Price = 96, Quantity=1 },
                new OrderDetail{OrderId = 9, BookId = 23,BookRating = 5, BookName = "The Handmaid's Tale", UserId = "763ec680-52e9-42be-8f8e-329e628c4144" ,Price = 78,Quantity=1 },
                //new OrderDetail{OrderId = 10, BookId = 22, Price = 90, Quantity=1 },
                //new OrderDetail{OrderId = 11, BookId = 22, Price = 90, Quantity=1 },
                //new OrderDetail{OrderId = 12, BookId = 24, Price = 95,Quantity=1 },
                //new OrderDetail{OrderId = 13, BookId = 18, Price = 94, Quantity=1 },
                new OrderDetail{OrderId = 14, BookId = 19,BookRating = 5,BookName = "Anna Karenina" , UserId = "763ec680-52e9-42be-8f8e-329e628c4144",Price = 85, Quantity=1 },
                new OrderDetail{OrderId = 15, BookId = 19, BookRating = 5,BookName = "Anna Karenina" , UserId = "763ec680-52e9-42be-8f8e-329e628c4144", Price = 85,Quantity=1 }
                //new OrderDetail{OrderId = 16, BookId = 26, Price = 88, Quantity=1 },
                //new OrderDetail{OrderId = 17, BookId = 16, Price = 80, Quantity=1 },
                //new OrderDetail{OrderId = 18, BookId = 21, Price = 100,Quantity=1 },
                //new OrderDetail{OrderId = 19, BookId = 21, Price = 100, Quantity=1 },
                //new OrderDetail{OrderId = 20, BookId = 21, Price = 100, Quantity=1 },
                //new OrderDetail{OrderId = 21, BookId = 19, Price = 85,Quantity=1 },
                //new OrderDetail{OrderId = 22, BookId = 15, Price = 85, Quantity=1 }
            };



            // Look for any Branches.
            if (!context.Branches.Any())
            {
                foreach (Branch c in branches)
                {
                    context.Branches.Add(c);
                }
                context.SaveChanges();
            }

           

            // Look for any ProductTypes.
            if (!context.Genres.Any())
            {
                foreach (Genre u in genres)
                {
                    context.Genres.Add(u);
                }
                context.SaveChanges();
            }

            // Look for any Products.
            if (!context.Books.Any())
            {
                foreach (Book e in books)
                {
                    context.Books.Add(e);
                }

                context.SaveChanges();
            }

            // Look for any Orders.
            if (!context.Orders.Any())
            {
                foreach (Order p in orders)
                {
                    context.Orders.Add(p);
                }
                context.SaveChanges();
            }

            // Look for any OrderDetails.
            if (!context.OrderDetails.Any())
            {
                foreach (OrderDetail p in orderDetails)
                {
                    context.OrderDetails.Add(p);
                }
                context.SaveChanges();
            }



            return;
        }
    }
}
