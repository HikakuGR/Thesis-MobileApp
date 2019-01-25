#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by the ClassGenerator.ttinclude code generation file.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Common;
using System.Collections.Generic;
using Telerik.OpenAccess;
using Telerik.OpenAccess.Metadata;
using Telerik.OpenAccess.Data.Common;
using Telerik.OpenAccess.Metadata.Fluent;
using Telerik.OpenAccess.Metadata.Fluent.Advanced;
using Coordination.Model;

namespace Coordination.Model	
{
	[Table()]
	[KeyGenerator(KeyGenerator.Autoinc)]
	public partial class User
	{
		private string _username;
		[Storage("_username")]
		[System.ComponentModel.DataAnnotations.Required()]
		public virtual string Username
		{
			get
			{
				return this._username;
			}
			set
			{
				this._username = value;
			}
		}
		
		private string _password;
		[Storage("_password")]
		[System.ComponentModel.DataAnnotations.Required()]
		public virtual string Password
		{
			get
			{
				return this._password;
			}
			set
			{
				this._password = value;
			}
		}
		
		private int _iD;
		[Column(IsPrimaryKey = true)]
		[Storage("_iD")]
		[System.ComponentModel.DataAnnotations.Required()]
		public virtual int ID
		{
			get
			{
				return this._iD;
			}
			set
			{
				this._iD = value;
			}
		}
		
		private string _email;
		[Storage("_email")]
		[System.ComponentModel.DataAnnotations.Required()]
		public virtual string Email
		{
			get
			{
				return this._email;
			}
			set
			{
				this._email = value;
			}
		}
		
		private string _latitude;
		[Storage("_latitude")]
		[System.ComponentModel.DataAnnotations.Required()]
		public virtual string Latitude
		{
			get
			{
				return this._latitude;
			}
			set
			{
				this._latitude = value;
			}
		}
		
		private string _longitude;
		[Storage("_longitude")]
		[System.ComponentModel.DataAnnotations.Required()]
		public virtual string Longitude
		{
			get
			{
				return this._longitude;
			}
			set
			{
				this._longitude = value;
			}
		}
		
		private IList<Job> _jobs = new List<Job>();
		[JoinTableAssociation(IsManaged = true)]
		[Storage("_jobs")]
		public virtual IList<Job> Jobs
		{
			get
			{
				return this._jobs;
			}
		}
		
	}
}
#pragma warning restore 1591