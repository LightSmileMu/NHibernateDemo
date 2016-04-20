
namespace Domain
{
    public class Class
    {
        public virtual int ID { get; set; }
        public virtual string Name { get; set; }
        public virtual Teacher Teacher { get; set; }
    }

    public class Student
    {
        public virtual int ID { get; set; }
        public virtual string Name { get; set; }
        public virtual Class Class { get; set; }
        public virtual Family Family { get; set; }
    }

    public class Family
    {
        public virtual int ID { get; set; }
        public virtual string Address { get; set; }
        public virtual Student Student { get; set; }
    }

    public class Teacher
    {
        public virtual int ID { get; set; }

        public virtual string Name { get; set; }

        public virtual Class Class { get; set; }
    }
}
