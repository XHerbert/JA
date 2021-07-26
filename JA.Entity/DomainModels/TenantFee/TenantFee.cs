using Newtonsoft.Json;
/*
 *Author：xuhbd
 *Contact：xuhbd@foxmail.com
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果数据库字段发生变化，请在代码生器重新生成此Model
 */
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JA.Entity.SystemModels;

namespace JA.Entity.DomainModels
{
    [Entity(TableCnName = "房租收取",TableName = "Tenant_fee")]
[Table("Tenant_fee")]
    public class TenantFee : BaseEntity
    {
        /// <summary>
       ///序号
       /// </summary>
       [Key]
       [Display(Name ="序号")]
       [Column(TypeName="int")]
       [Required(AllowEmptyStrings=false)]
       public int Id { get; set; }

       /// <summary>
       ///流水编码
       /// </summary>
       [Display(Name ="流水编码")]
       [MaxLength(100)]
       [Column(TypeName="nvarchar(100)")]
       public string Code { get; set; }

       /// <summary>
       ///租客标识
       /// </summary>
       [Display(Name ="租客标识")]
       [Column(TypeName="int")]
       [Required(AllowEmptyStrings=false)]
       public int TenantId { get; set; }

       /// <summary>
       ///房屋标识
       /// </summary>
       [Display(Name ="房屋标识")]
       [Column(TypeName="int")]
       [Required(AllowEmptyStrings=false)]
       public int HouseId { get; set; }

       /// <summary>
       ///应收租金
       /// </summary>
       [Display(Name ="应收租金")]
       [DisplayFormat(DataFormatString="10,2")]
       [Column(TypeName="decimal")]
       [Required(AllowEmptyStrings=false)]
       public decimal Receivable { get; set; }

       /// <summary>
       ///预收租金
       /// </summary>
       [Display(Name ="预收租金")]
       [DisplayFormat(DataFormatString="10,2")]
       [Column(TypeName="decimal")]
       public decimal? PreReceivable { get; set; }

       /// <summary>
       ///冲减预收租金
       /// </summary>
       [Display(Name ="冲减预收租金")]
       [DisplayFormat(DataFormatString="10,2")]
       [Column(TypeName="decimal")]
       public decimal? OffsetPreReceivable { get; set; }

       /// <summary>
       ///收欠收租金
       /// </summary>
       [Display(Name ="收欠收租金")]
       [DisplayFormat(DataFormatString="10,2")]
       [Column(TypeName="decimal")]
       public decimal? UnPaidRent { get; set; }

       /// <summary>
       ///实收租金
       /// </summary>
       [Display(Name ="实收租金")]
       [DisplayFormat(DataFormatString="10,2")]
       [Column(TypeName="decimal")]
       public decimal? ActualPaidRent { get; set; }

       /// <summary>
       ///缴费状态
       /// </summary>
       [Display(Name ="缴费状态")]
       [Column(TypeName="int")]
       public int? PayStatus { get; set; }

       /// <summary>
       ///收现金
       /// </summary>
       [Display(Name ="收现金")]
       [Column(TypeName="decimal")]
       public decimal? Crash { get; set; }

       /// <summary>
       ///期数
       /// </summary>
       [Display(Name ="期数")]
       [MaxLength(10)]
       [Column(TypeName="nvarchar(10)")]
       public string Period { get; set; }

       /// <summary>
       ///银行托收
       /// </summary>
       [Display(Name ="银行托收")]
       [DisplayFormat(DataFormatString="10,2")]
       [Column(TypeName="decimal")]
       public decimal? FeeFromBank { get; set; }

       /// <summary>
       ///银行未托
       /// </summary>
       [Display(Name ="银行未托")]
       [DisplayFormat(DataFormatString="10,2")]
       [Column(TypeName="decimal")]
       public decimal? NoFeeToBank { get; set; }

       /// <summary>
       ///创建人标识
       /// </summary>
       [Display(Name ="创建人标识")]
       [JsonIgnore]
       [Column(TypeName="int")]
       [Required(AllowEmptyStrings=false)]
       public int CreatorID { get; set; }

       /// <summary>
       ///创建人
       /// </summary>
       [Display(Name ="创建人")]
       [MaxLength(20)]
       [Column(TypeName="nvarchar(20)")]
       [Required(AllowEmptyStrings=false)]
       public string Creator { get; set; }

       /// <summary>
       ///创建时间
       /// </summary>
       [Display(Name ="创建时间")]
       [Column(TypeName="datetime")]
       public DateTime? CreateDate { get; set; }

       /// <summary>
       ///修改人标识
       /// </summary>
       [Display(Name ="修改人标识")]
       [JsonIgnore]
       [Column(TypeName="int")]
       public int? ModifyID { get; set; }

       /// <summary>
       ///修改时间
       /// </summary>
       [Display(Name ="修改时间")]
       [JsonIgnore]
       [Column(TypeName="datetime")]
       public DateTime? ModifyDate { get; set; }

       /// <summary>
       ///修改人
       /// </summary>
       [Display(Name ="修改人")]
       [MaxLength(20)]
       [JsonIgnore]
       [Column(TypeName="nvarchar(20)")]
       public string Modifier { get; set; }

       
    }
}
