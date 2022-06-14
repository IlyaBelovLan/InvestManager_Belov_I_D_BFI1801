namespace InvestManager.Database.Models
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using Context;

    [Table(nameof(DatabaseContext.Notes))]
    public class EntityNote
    {
        public long Id { get; set; }
        
        public string Symbol { get; set; }
        
        public string Text { get; set; }
        
        public DateTime CreateDate { get; set; }
        
        public long EntityUserId { get; set; }
        
        public EntityUser EntityUser { get; set; }
    }
}