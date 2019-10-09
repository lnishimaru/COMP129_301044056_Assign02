using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using COMP229_301044056_Assign02.Models;

namespace COMP229_301044056_Assign02.Models
{
    public class RecipeCollection
    {
        private List<RecipeBook> lineCollection = new List<RecipeBook>();
        public virtual void AddItem(Recipe recipe)
        {
            RecipeBook line = lineCollection
            .Where(p => p.Recipe.ID == recipe.ID)
            .FirstOrDefault();
            if (line == null)
            {
                lineCollection.Add(new RecipeBook
                {
                    Recipe = recipe,
                });
            }
        }
        public virtual void RemoveLine(Recipe recipe) =>
        lineCollection.RemoveAll(l => l.Recipe.ID == recipe.ID);
        public virtual void Clear() => lineCollection.Clear();
        public virtual IEnumerable<RecipeBook> Lines => lineCollection;
    }
    public class RecipeBook
    {
        public int ID { get; set; }
        public Recipe Recipe { get; set; }
    }

}
