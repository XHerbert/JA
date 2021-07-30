using Newtonsoft.Json;
/*
 *Author：xuhbd
 *Contact：xuhbd@foxmail.com
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果数据库字段发生变化，请在代码生器重新生成此Model
 */
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using JA.Entity.SystemModels;

namespace JA.Entity.DomainModels
{
    [Entity(TableCnName = "租客管理", TableName = "Tenant")]
    public class Tenant : BaseEntity
    {
        /// <summary>
        ///序号
        /// </summary>
        [Key]
        [Display(Name = "序号")]
        [Column(TypeName = "int")]
        [Required(AllowEmptyStrings = false)]
        public int Id { get; set; }

        /// <summary>
        ///编号
        /// </summary>
        [Display(Name = "编号")]
        [MaxLength(30)]
        [Column(TypeName = "nvarchar(30)")]
        [Editable(true)]
        public string TenantCode { get; set; }

        /// <summary>
        ///户主姓名
        /// </summary>
        [Display(Name = "户主姓名")]
        [MaxLength(30)]
        [Column(TypeName = "nvarchar(30)")]
        [Editable(true)]
        public string TenantName { get; set; }

        /// <summary>
        ///性别
        /// </summary>
        [Display(Name = "性别")]
        [Column(TypeName = "int")]
        [Editable(true)]
        public int? Gender { get; set; }

        /// <summary>
        ///手机电话
        /// </summary>
        [Display(Name = "手机电话")]
        [MaxLength(30)]
        [Column(TypeName = "nvarchar(30)")]
        [Editable(true)]
        public string Mobile { get; set; }

        /// <summary>
        ///身份证号
        /// </summary>
        [Display(Name = "身份证号")]
        [MaxLength(20)]
        [Column(TypeName = "nvarchar(20)")]
        [Editable(true)]
        public string IdCard { get; set; }

        /// <summary>
        ///详细地址
        /// </summary>
        [Display(Name = "详细地址")]
        [MaxLength(400)]
        [Column(TypeName = "nvarchar(400)")]
        [Editable(true)]
        public string Address { get; set; }

        /// <summary>
        ///租金
        /// </summary>
        [Display(Name = "租金")]
        [DisplayFormat(DataFormatString = "10,2")]
        [Column(TypeName = "decimal")]
        public decimal? RentFee { get; set; }

        /// <summary>
        ///缴款账号
        /// </summary>
        [Display(Name = "缴款账号")]
        [MaxLength(45)]
        [Column(TypeName = "nvarchar(45)")]
        [Editable(true)]
        public string BankCard { get; set; }

        /// <summary>
        ///户名
        /// </summary>
        [Display(Name = "户名")]
        [MaxLength(450)]
        [Column(TypeName = "nvarchar(450)")]
        [Editable(true)]
        public string AccountName { get; set; }

        /// <summary>
        ///开户行
        /// </summary>
        [Display(Name = "开户行")]
        [MaxLength(45)]
        [Column(TypeName = "nvarchar(45)")]
        [Editable(true)]
        public string Bank { get; set; }

        /// <summary>
        ///是否有效
        /// </summary>
        [Display(Name = "是否有效")]
        [JsonIgnore]
        [Column(TypeName = "int")]
        [Editable(true)]
        public int? EnableFlag { get; set; }

        /// <summary>
        ///创建人ID
        /// </summary>
        [Display(Name = "创建人ID")]
        [JsonIgnore]
        [Column(TypeName = "int")]
        [Required(AllowEmptyStrings = false)]
        public int CreatorID { get; set; }

        /// <summary>
        ///创建人
        /// </summary>
        [Display(Name = "创建人")]
        [MaxLength(30)]
        [JsonIgnore]
        [Column(TypeName = "nvarchar(30)")]
        [Required(AllowEmptyStrings = false)]
        public string Creator { get; set; }

        /// <summary>
        ///创建日期
        /// </summary>
        [Display(Name = "创建日期")]
        [JsonIgnore]
        [Column(TypeName = "datetime")]
        public DateTime? CreateDate { get; set; }

        /// <summary>
        ///修改人ID
        /// </summary>
        [Display(Name = "修改人ID")]
        [JsonIgnore]
        [Column(TypeName = "int")]
        public int? ModifyID { get; set; }

        /// <summary>
        ///修改时间
        /// </summary>
        [Display(Name = "修改时间")]
        [JsonIgnore]
        [Column(TypeName = "datetime")]
        public DateTime? ModifyDate { get; set; }

        /// <summary>
        ///修改人
        /// </summary>
        [Display(Name = "修改人")]
        [MaxLength(30)]
        [JsonIgnore]
        [Column(TypeName = "nvarchar(30)")]
        public string Modifier { get; set; }

        /// <summary>
        ///所属单位
        /// </summary>
        [Display(Name = "所属单位")]
        [JsonIgnore]
        [Column(TypeName = "int")]
        [Editable(true)]
        public int? BelongUnit { get; set; }


    }
}
