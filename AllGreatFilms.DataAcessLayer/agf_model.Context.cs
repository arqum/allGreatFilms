﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AllGreatFilms.DataAcessLayer
{
    using AllGreatFilms.BusinessObjectLayer;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class agf_context : DbContext
    {
        public agf_context()
            : base("name=agf_context")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<actor> actors { get; set; }
        public virtual DbSet<award> awards { get; set; }
        public virtual DbSet<country> countries { get; set; }
        public virtual DbSet<director> directors { get; set; }
        public virtual DbSet<genre> genres { get; set; }
        public virtual DbSet<language> languages { get; set; }
        public virtual DbSet<mood> moods { get; set; }
        public virtual DbSet<movie> movies { get; set; }
        public virtual DbSet<movie_quotes> movie_quotes { get; set; }
        public virtual DbSet<rating> ratings { get; set; }
        public virtual DbSet<user> users { get; set; }
        public virtual DbSet<user_profile> user_profile { get; set; }
        public virtual DbSet<writer> writers { get; set; }
        public virtual DbSet<user_watched_movies> user_watched_movies { get; set; }
    }
}