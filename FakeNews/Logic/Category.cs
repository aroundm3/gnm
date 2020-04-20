using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace GameNews.Logic
{
    class Category
    {
        public int id { get; set; }
        public string categoryname { get; set; }
        public Category(int id, string name)
        {
            this.id = id;
            this.categoryname = name;
        }

    }
    class CategoryList
    {
        public static List<Category> getAllCategory()
        {
            List<Category> categories = new List<Category>();
            DataTable dt = FakeNews.DataAccess.CategoryDAO.getAllCategory();
            categories.Add(new Category(0, "All Category"));
            foreach(DataRow dr in dt.Rows)
            {
                Category category = new Category(Convert.ToInt32(dr["categoryid"]), dr["categoryname"].ToString());
                categories.Add(category);
            }
            return categories;
        }    
    }
}
