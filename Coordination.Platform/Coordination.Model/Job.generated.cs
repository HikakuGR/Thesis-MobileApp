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
	public partial class Job
	{
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
		
		private string _description;
		[Storage("_description")]
		[System.ComponentModel.DataAnnotations.Required()]
		public virtual string Description
		{
			get
			{
				return this._description;
			}
			set
			{
				this._description = value;
			}
		}
		
		private bool? _completed;
		[Storage("_completed")]
		[System.ComponentModel.DataAnnotations.Required()]
		public virtual bool? Completed
		{
			get
			{
				return this._completed;
			}
			set
			{
				this._completed = value;
			}
		}
		
		private bool? _assigned;
		[Storage("_assigned")]
		[System.ComponentModel.DataAnnotations.Required()]
		public virtual bool? Assigned
		{
			get
			{
				return this._assigned;
			}
			set
			{
				this._assigned = value;
			}
		}
		
		private string _jobName;
		[Storage("_jobName")]
		[System.ComponentModel.DataAnnotations.Required()]
		public virtual string JobName
		{
			get
			{
				return this._jobName;
			}
			set
			{
				this._jobName = value;
			}
		}
		
		private IList<User> _users = new List<User>();
		[Collection(InverseProperty = "Jobs", IsManaged = true)]
		[Storage("_users")]
		public virtual IList<User> Users
		{
			get
			{
				return this._users;
			}
		}
		
	}
}
#pragma warning restore 1591