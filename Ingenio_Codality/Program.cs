using System;
using System.Collections.Generic;
using System.Linq;

namespace Ingenio_Codality
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(check(201));
        }

        static string check(int X)
        {
            List<Category> categories = new List<Category>();
            Parent p1 = new Parent(-1, "Money");
            Parent p2 = new Parent(-1, "Teaching");
            Parent p3 = new Parent(100, "Taxes");
            Parent p4 = new Parent(100, "");
            Parent p5 = new Parent(200, "");
            Parent p6 = new Parent(101, "");
            Parent p7 = new Parent(201, "");
            Parent p8 = new Parent(101, "");

            Category c1 = new Category(100, p1, "Business");
            Category c2 = new Category(200, p2, "Tutoring");
            Category c3 = new Category(101, p3, "Accounting");
            Category c4 = new Category(102, p4, "Taxation");
            Category c5 = new Category(201, p5, "Computer");
            Category c6 = new Category(100, p6, "Corporate Tax");
            Category c7 = new Category(203, p7, "Operating System");
            Category c8 = new Category(200, p8, "Small Business Tax");
            categories.Add(c1);
            categories.Add(c2);
            categories.Add(c3);
            categories.Add(c4);
            categories.Add(c5);
            categories.Add(c6);
            categories.Add(c7);
            categories.Add(c8);
            var item = categories.Where(x => x.Id == X).FirstOrDefault();
            string okey = "";
            string output = "";
            string name = "";
            string parentId = "";
            if (item != null)
            {
                while (item.ParentId != null)
                {
                    if (item.ParentId.keyword == "")
                    {
                        var newx = item.ParentId.Id;
                        var newitem = categories.Where(x => x.Id == newx).FirstOrDefault();
                        item = newitem;
                    }
                    else
                    {
                        okey = item.ParentId.keyword;
                        break;
                    }
                }
                parentId = item.ParentId.Id.ToString();
                name = item.Name;
            }

            output = $"ParentId = {parentId}, Name = {name}, Keyword= {okey}";
            return output;
        }
    }

    class Parent
    {
        public int Id { get; set; }
        public string keyword { get; set; }
        public Parent(int id, string key)
        {
            this.Id = id;
            this.keyword = key;
        }
    }

    class Category
    {
        public int Id { get; set; }
        public Parent ParentId { get; set; }
        public string Name { get; set; }
        public Category(int id, Parent parent, string n)
        {
            this.Id = id;
            this.ParentId = parent;
            this.Name = n;
        }
    }
}
