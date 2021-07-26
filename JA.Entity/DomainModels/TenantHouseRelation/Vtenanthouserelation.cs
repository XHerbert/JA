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
    [Entity(TableCnName = "房屋分配",TableName = "Vtenanthouserelation")]
    public class Vtenanthouserelation:BaseEntity
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
       ///房号
       /// </summary>
       [Display(Name ="房号")]
       [MaxLength(25)]
       [Column(TypeName="nvarchar(25)")]
       [Required(AllowEmptyStrings=false)]
       public string HouseNumber { get; set; }

       /// <summary>
       ///租客编码
       /// </summary>
       [Display(Name ="租客编码")]
       [MaxLength(30)]
       [Column(TypeName="nvarchar(30)")]
       [Required(AllowEmptyStrings=false)]
       public string TenantCode { get; set; }

       /// <summary>
       ///房屋状态
       /// </summary>
       [Display(Name ="房屋状态")]
       [Column(TypeName="int")]
       [Required(AllowEmptyStrings=false)]
       public int HouseStatus { get; set; }

       /// <summary>
       ///租客名称
       /// </summary>
       [Display(Name ="租客名称")]
       [MaxLength(30)]
       [Column(TypeName="nvarchar(30)")]
       [Required(AllowEmptyStrings=false)]
       public string TenantName { get; set; }

       /// <summary>
       ///房屋编码
       /// </summary>
       [Display(Name ="房屋编码")]
       [MaxLength(45)]
       [Column(TypeName="nvarchar(45)")]
       [Required(AllowEmptyStrings=false)]
       public string HouseCode { get; set; }

       /// <summary>
       ///性别
       /// </summary>
       [Display(Name ="性别")]
       [Column(TypeName="int")]
       public int? Gender { get; set; }

       /// <summary>
       ///房屋类型
       /// </summary>
       [Display(Name ="房屋类型")]
       [Column(TypeName="int")]
       public int? HouseType { get; set; }

       /// <summary>
       ///身份证
       /// </summary>
       [Display(Name ="身份证")]
       [MaxLength(20)]
       [Column(TypeName="nvarchar(20)")]
       public string IdCard { get; set; }

       /// <summary>
       ///手机号
       /// </summary>
       [Display(Name ="手机号")]
       [MaxLength(11)]
       [Column(TypeName="nvarchar(11)")]
       public string Mobile { get; set; }

       /// <summary>
       ///房屋租金
       /// </summary>
       [Display(Name ="房屋租金")]
       [DisplayFormat(DataFormatString="10,2")]
       [Column(TypeName="decimal")]
       [Required(AllowEmptyStrings=false)]
       public decimal RentFee { get; set; }

       /// <summary>
       ///实际租金
       /// </summary>
       [Display(Name ="实际租金")]
       [DisplayFormat(DataFormatString="10,2")]
       [Column(TypeName="decimal")]
       [Editable(true)]
       public decimal? ActualRentFee { get; set; }

       /// <summary>
       ///入住时间
       /// </summary>
       [Display(Name ="入住时间")]
       [Column(TypeName="datetime")]
       [Editable(true)]
       public DateTime? LiveTime { get; set; }

       /// <summary>
       ///房屋
       /// </summary>
       [Display(Name ="房屋")]
       [JsonIgnore]
       [Column(TypeName="int")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public int HouseId { get; set; }

       /// <summary>
       ///租客
       /// </summary>
       [Display(Name ="租客")]
       [JsonIgnore]
       [Column(TypeName="int")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public int TenantId { get; set; }

       /// <summary>
       ///所属单位
       /// </summary>
       [Display(Name ="所属单位")]
       [JsonIgnore]
       [Column(TypeName="int")]
       public int? BelongUnit { get; set; }

       
    }
}
