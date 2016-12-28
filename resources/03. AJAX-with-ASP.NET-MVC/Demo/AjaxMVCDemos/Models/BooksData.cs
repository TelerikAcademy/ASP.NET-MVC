namespace AjaxMVCDemos.Models
{
    using System.Collections.Generic;

    public static class BooksData
    {
        public static List<Book> GetAll()
        {
            return new List<Book>
            {
                new Book
                    {
                        Id = 1,
                        Title = "The Count of Monte Cristo",
                        Content = "The Count of Monte Cristo (French: Le Comte de Monte-Cristo) is an adventure novel by French author Alexandre Dumas (père) completed in 1844. It is one of the author's most popular works, along with The Three Musketeers. Like many of his novels, it is expanded from plot outlines suggested by his collaborating ghostwriter Auguste Maquet.[1]. The story takes place in France, Italy and islands in the Mediterranean during the historical events of 1815–1838. It begins from just before the Hundred Days period (when Napoleon returned to power after his exile) and spans through to the reign of Louis-Philippe of France. The historical setting is a fundamental element of the book. An adventure story primarily concerned with themes of hope, justice, vengeance, mercy and forgiveness, it focuses on a man who is wrongfully imprisoned, escapes from jail, acquires a fortune and sets about getting revenge on those responsible for his imprisonment. However, his plans have devastating consequences for the innocent as well as the guilty. In addition, it is a story that involves romance, loyalty, betrayal and selfishness, shown throughout the story as characters slowly reveal their true inner nature.",
                        Sales = 1000.0m,
                        Taxes = 800.0m
                    },
                     new Book
                    {
                        Id = 2,
                        Title = "Of Mice and Men",
                        Content = "Of Mice and Men is a novella[1][2] written by Nobel Prize-winning author John Steinbeck. Published in 1937, it tells the story of George Milton and Lennie Small, two displaced migrant ranch workers, who move from place to place in search of new job opportunities during the Great Depression in California, United States. Based on Steinbeck's own experiences as a bindlestiff in the 1920s (before the arrival of the Okies he would vividly describe in The Grapes of Wrath), the title is taken from Robert Burns' poem \"To a Mouse\", which read: \"The best laid schemes o' mice an' men / Gang aft agley.\" (The best laid schemes of mice and men / Often go awry.) Required reading in many schools,[3] Of Mice and Men has been a frequent target of censors for vulgarity and what some consider offensive and racist language; consequently, it appears on the American Library Association's list of the Most Challenged Books of 21st Century.[4]",
                        Sales = 120.0m,
                        Taxes = 5.0m
                    },
                     new Book
                    {
                        Id = 3,
                        Title = "The Little Prince",
                        Content = "The Little Prince (French: Le Petit Prince; French pronunciation: ​[lə.pə.tiˈpʁɛ̃s]), first published in 1943, is a novella and the most famous work of the French aristocrat, writer, poet and pioneering aviator Antoine de Saint-Exupéry (1900–1944). The novella is both the most-read and most-translated book in the French language, and was voted the best book of the 20th century in France. Translated into more than 250 languages and dialects (as well as braille),[3][4] selling nearly two million copies annually with sales totalling over 140 million copies worldwide,[5] it has become one of the top best-selling books ever published.[6][7][8][Note 3] After the outbreak of the Second World War Saint-Exupéry became exiled in North America. In the midst of personal upheavals and failing health, he produced almost half of the writings for which he would be remembered, including a tender tale of loneliness, friendship, love and loss, in the form of a young prince fallen to Earth. An earlier memoir by the author had recounted his aviation experiences in the Sahara Desert, and he is thought to have drawn on those same experiences in The Little Prince. Since its first publication in the United States, the novella has been adapted to numerous art forms and media, including audio recordings, radio plays, live stage, film screen, television, ballet, and operatic works.[3][10]",
                        Sales = 1500.0m,
                        Taxes = 70.0m
                    },
                     new Book
                    {
                        Id = 4,
                        Title = "Robinson Crusoe",
                        Content = "Robinson Crusoe /rɒbɪnsən ˈkruːsoʊ/ is a novel by Daniel Defoe, first published on 25 April 1719. This first edition credited the work's fictional protagonist Robinson Crusoe as its author, leading many readers to believe he was a real person and the book a travelogue of true incidents.[2] It was published under the considerably longer original title The Life and Strange Surprizing Adventures of Robinson Crusoe, Of York, Mariner: Who lived Eight and Twenty Years, all alone in an un-inhabited Island on the Coast of America, near the Mouth of the Great River of Oroonoque; Having been cast on Shore by Shipwreck, wherein all the Men perished but himself. With An Account how he was at last as strangely deliver'd by Pyrates. Epistolary, confessional, and didactic in form, the book is a fictional autobiography of the title character (whose birth name is Robinson Kreutznaer)—a castaway who spends years on a remote tropical island near Trinidad, encountering cannibals, captives, and mutineers before being rescued. The story is widely perceived to have been influenced by the life of Alexander Selkirk, a Scottish castaway who lived for four years on the Pacific island called \"Más a Tierra\" (in 1966 its name was changed to Robinson Crusoe Island), Chile. However, other possible sources have been put forward for the text. It is possible, for example, that Defoe was inspired by the Latin or English translations of Ibn Tufail's Hayy ibn Yaqdhan, an earlier novel also set on a desert island.[3][4][5][6] Another source for Defoe's novel may have been Robert Knox's account of his abduction by the King of Ceylon in 1659 in \"An Historical Account of the Island Ceylon,\" Glasgow: James MacLehose and Sons (Publishers to the University), 1911.[7] In his 2003 book In Search of Robinson Crusoe, Tim Severin contends that the account of Henry Pitman in a short book chronicling his escape from a Caribbean penal colony and subsequent shipwrecking and desert island misadventures, is the inspiration for the story. Arthur Wellesley Secord in his Studies in the narrative method of Defoe (1963: 21–111) painstakingly analyses the composition of Robinson Crusoe and gives a list of possible sources of the story, rejecting the common theory that the story of Selkirk is Defoe's only source.",
                        Sales = 1800.0m,
                        Taxes = 90.0m
                    },
                     new Book
                    {
                        Id = 5,
                        Title = "Introduction to programming",
                        Content = "It aims to provide novice programmers solid foundation of basic knowledge regardless of the programming language. This book covers the fundamentals of programming that have not changed significantly over the last 10 years. Educational content was developed by an authoritative author team led by Svetlin Nakov and covers topics such as variables conditional statements, loops and arrays, and more complex concepts such as data structures (lists, stacks, queues, trees, hash tables, etc.), and recursion recursive algorithms, object-oriented programming and high-quality code. From the book you will learn how to think as programmers and how to solve efficiently programming problems. You will master the fundamental principles of programming and basic data structures and algorithms, without which you can't become a software engineer.",
                        Sales = 500.0m,
                        Taxes = 68.0m
                    }
            };
        }
    }
}