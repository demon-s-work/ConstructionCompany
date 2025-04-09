using System;

namespace StaemDatabaseApp.Model
{
	public class WorkType
	{
        public WorkType(string id, string title, string description, decimal cost)
        {
            int id_ = 0;
            Int32.TryParse(id, out id_);

            Id = id_;
        }

        private int id;
        private string title;
        private string description;
        private decimal cost;
        
        
        public string Title { get => title; set => title = value; }
        public string Description { get => description; set => description = value; }
        public decimal Cost { get => cost; set => cost = value; }
        public int Id { get => id; set => id = value; }

        public override string ToString()
        {
            return  title + " : " + Id.ToString();
        }

	}
}