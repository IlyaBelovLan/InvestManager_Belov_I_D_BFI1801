namespace InvestManager.Database.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using Context;

    [Table(nameof(DatabaseContext.Users))]
    public class EntityUser
    {
        public long Id { get; set; }
        
        public string UserName { get; set; }
        
        public string Email { get; set; }
        
        public string PasswordHash { get; set; }

        public ICollection<EntityNote> EntityNotes { get; set; } = new List<EntityNote>();
    }
}