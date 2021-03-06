﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace JobPosting.Models
{
    //Only let Applicant delete their own Application
    public class Application : Auditable
    {
        private bool available = true;
        private DateTime applyDate = DateTime.Now;
        public Application()
        {
            this.BinaryFiles = new HashSet<BinaryFile>();
            this.ApplicationsQualifications = new HashSet<ApplicationQualification>();
            this.ApplicationSkills = new HashSet<ApplicationSkill>();
        }


        public int ID { get; set; }


        //No need Display
        //Number base on the drag and drop position (1 -> infinity), the lowest number is at the highest priority
        public int Priority { get; set; }

        [Display(Name = "Posting")]
        [Required(ErrorMessage = "You have to specify Posting")]
        public int PostingID { get; set; }

        [Display(Name = "Applicant")]
        [Required(ErrorMessage = "You have to specify Applicant.")]
        public int ApplicantID { get; set; }

        [Display(Name = "Comment")]
        [StringLength(2000, ErrorMessage = "Comment must be less than 2000 characters")]
        [DataType(DataType.MultilineText)]
        public string Comment { get; set; }

        public bool Available {
            get {
                return available;
            }
            set {
                available = value;
            }

        }

        //[Display(Name = "Apply Date")]
        //public DateTime ApplyDate
        //{
        //    get { return applyDate; }
        //    set
        //    {
        //        value = applyDate;
        //    }
        //}


        public virtual Posting Posting { get; set; }

        public virtual Applicant Applicant { get; set; }

        //Qualifications that an Applicant have
        public virtual ICollection<ApplicationQualification> ApplicationsQualifications { get; set; }

        public virtual ICollection<BinaryFile> BinaryFiles { get; set; }

        public virtual ICollection<ApplicationSkill> ApplicationSkills { get; set; }
    }
}