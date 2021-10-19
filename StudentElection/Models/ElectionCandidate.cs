//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StudentElection.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ElectionCandidate
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ElectionCandidate()
        {
            this.ElectionVotes = new HashSet<ElectionVote>();
        }
    
        public int id { get; set; }
        public Nullable<int> ElectionId { get; set; }
        public Nullable<int> CandidatId { get; set; }
    
        public virtual Candidate Candidate { get; set; }
        public virtual Election Election { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ElectionVote> ElectionVotes { get; set; }
    }
}