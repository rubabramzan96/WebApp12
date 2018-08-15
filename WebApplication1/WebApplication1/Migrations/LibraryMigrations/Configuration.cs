namespace WebApplication1.Migrations.LibraryMigrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Linq;
    using System.Reflection;

    internal sealed class Configuration : DbMigrationsConfiguration<WebApplication1.Models.LibraryContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\LibraryMigrations";
        }

        protected override void Seed(WebApplication1.Models.LibraryContext context)
        {
            seedMember(context);
            seedBooks(context);
            //loanOutBook(context);
            SeedCourses(context);

        }
        private void seedMember(LibraryContext context)
        {
            #region Member1
            context.Members.AddOrUpdate(c => c.MemberId,
                        new Member
                        {
                            FirstName = "sararh",
                            SecondName = "aaaa",
                            DateJoined = DateTime.Now,
                            MemberId = 1,
                            //Members = SeedMembers(context),
                            //      memberLoan = new List<Loan>()
                            /*
                                                       memberLoan = new List<Loan>()
                                       {	// Create a Loan out on book to one memnber
                                                   new Loan { LoanId = 1,
                                                      MemberId = 1,
                                                      BookId=1,
                                                      // Update attendees with a method similar to the SeedClubMembers 
                                                      // See below
                                                   }

                                       } */
                        });
            #endregion
            #region Member2

            context.Members.AddOrUpdate(c => c.MemberId,
                        new Member
                        {
                            FirstName = "Tina",
                            SecondName = "bbbbb",
                            DateJoined = DateTime.Now,
                            MemberId = 2,
                            //Member = SeedMembers(context),
                            //      memberLoan = new List<Loan>()
                        });
            #endregion
            context.SaveChanges(); // NOTE EF will update the relevant foreign key fields in the clubs, club events and member tables based on the attributes
        }
        private void seedBooks(LibraryContext context)
        {
            #region Book1
            context.books.AddOrUpdate(c => c.BookId,
                        new Book
                        {
                            BookId = 1,
                            Title = "circle of friends ",
                            ISBN = "12345678",
                            Author = "Meave Binchy",

                            //Members = SeedMembers(context),
                            //      memberLoan = new List<Loan>()
                        });
            #endregion
            #region Book2
            context.books.AddOrUpdate(c => c.BookId,
                        new Book
                        {
                            BookId = 2,
                            Title = " friends ",
                            ISBN = "23456789",
                            Author = "aaaaaaaaa",
                            //Members = SeedMembers(context),
                            //      memberLoan = new List<Loan>()
                        });
            #endregion
            #region Book3
            context.books.AddOrUpdate(c => c.BookId,
                        new Book
                        {
                            BookId = 3,
                            Title = " Circle ",
                            ISBN = "34567890",
                            Author = "bbbbbb",
                            //Members = SeedMembers(context),
                            //      memberLoan = new List<Loan>()
                        });
            #endregion
            context.SaveChanges(); // NOTE EF will update the relevant foreign key fields in the clubs, club events and member tables based on the attributes
        }

        /*    private void loanOutBook(LibraryContext context)
       {
           // Create a list to hold students
           List<Member> selectedStudents = new List<loan>();
            //save first , then retrieve them as a list
           foreach (var  in context.Clubs.ToList())
           {
               //set member if not set yet
               if (club.clubMembers == null || club.clubMembers.Count() < 1)
               {
                   //set randoms one --method below
                   selectedStudents = GetStudents(context);
                   foreach (var m in selectedStudents)
                   {
                       //new member with a ref to a club ,EF will join fields later
                       context.members.AddOrUpdate(member => member.StudentID,
                           new Member { ClubId = club.ClubId, StudentID = m.StudentID });
                    }
               }
           }
           context.SaveChanges();
       } */

        public static void SeedCourses(LibraryContext context)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            string resourceName = "WebApplication1.Migrations.LibraryMigrations.Courses.csv";
            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
             using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                {
                    CsvReader csvReader = new CsvReader(reader);
                    csvReader.Configuration.HasHeaderRecord = false;
                    var courseData = csvReader.GetRecords<CourseDataImport>().ToArray();
                    foreach (var dataItem in courseData)
                    {
                        context.Courses.AddOrUpdate(c =>
                                new { c.CourseCode, c.CourseName },
                                new Course
                                {
                                    CourseCode = dataItem.CourseCode,
                                    CourseName = dataItem.CourseName,
                                    CourseYear = dataItem.Year
                                });
                    }
                }
            context.SaveChanges();
        }
          
        }
    }

