//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TechSupport
{
    using System;
    using System.Collections.Generic;
    
    public partial class Answer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Answer()
        {
            this.Answers1 = new HashSet<Answer>();
        }
    
        public int Id { get; set; }
        public Nullable<int> Question { get; set; }
        public Nullable<int> ReplyOn { get; set; }
        public string Author { get; set; }
        public System.DateTime TimeCreated { get; set; }
        public string Text { get; set; }
        public int Upvotes { get; set; }
        public int Downvotes { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Answer> Answers1 { get; set; }
        public virtual Answer Answer1 { get; set; }
        public virtual AspNetUser AspNetUser { get; set; }
        public virtual Question Question1 { get; set; }
    }
}
