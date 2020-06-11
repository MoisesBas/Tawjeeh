using FluentMigrator;

namespace Tawjeeh.DbMigration
{
    public class DbTawjeehMigrationAttribute: MigrationAttribute
    {
        public DbTawjeehMigrationAttribute(int branchNumber, int year, int month, int day, int hour, int minute, string author)
       : base(CalculateValue(branchNumber, year, month, day, hour, minute))
        {
            this.Author = author;
        }
        public DbTawjeehMigrationAttribute(int branchNumber, int year, int month, int day, string author)
       : base(CalculateValue(branchNumber, year, month, day))
        {
            this.Author = author;
        }
        public string Author { get; private set; }
        private static long CalculateValue(int branchNumber, int year, int month, int day, int hour, int minute)
        {
            return branchNumber * 1000000000000L + year * 100000000L + month * 1000000L + day * 10000L + hour * 100L + minute;
        }
        private static long CalculateValue(int branchNumber, int year, int month, int day)
        {
            return branchNumber * 1000000000000L + year * 100000000L + month * 1000000L + day;
        }
    }
}
