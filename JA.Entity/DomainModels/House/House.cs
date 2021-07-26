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
    [Entity(TableCnName = "房屋管理",TableName = "House")]
    public class House:BaseEntity
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
       ///房屋编码
       /// </summary>
       [Display(Name ="房屋编码")]
       [MaxLength(45)]
       [Column(TypeName="nvarchar(45)")]
       public string HouseCode { get; set; }

       /// <summary>
       ///房屋面积
       /// </summary>
       [Display(Name ="房屋面积")]
       [DisplayFormat(DataFormatString="10,2")]
       [Column(TypeName="decimal")]
       [Editable(true)]
       public decimal? Area { get; set; }

       /// <summary>
       ///县区
       /// </summary>
       [Display(Name ="县区")]
       [MaxLength(450)]
       [Column(TypeName="nvarchar(450)")]
       [Editable(true)]
       public string District { get; set; }

       /// <summary>
       ///乡镇（街道）
       /// </summary>
       [Display(Name ="乡镇（街道）")]
       [MaxLength(450)]
       [Column(TypeName="nvarchar(450)")]
       [Editable(true)]
       public string Township { get; set; }

       /// <summary>
       ///社区（村委会）
       /// </summary>
       [Display(Name ="社区（村委会）")]
       [MaxLength(450)]
       [Column(TypeName="nvarchar(450)")]
       [Editable(true)]
       public string Village { get; set; }

       /// <summary>
       ///小区
       /// </summary>
       [Display(Name ="小区")]
       [MaxLength(245)]
       [Column(TypeName="nvarchar(245)")]
       public string Group { get; set; }

       /// <summary>
       ///楼栋号
       /// </summary>
       [Display(Name ="楼栋号")]
       [MaxLength(45)]
       [Column(TypeName="nvarchar(45)")]
       [Editable(true)]
       public string BuildingNumber { get; set; }

       /// <summary>
       ///单元号
       /// </summary>
       [Display(Name ="单元号")]
       [MaxLength(45)]
       [Column(TypeName="nvarchar(45)")]
       [Editable(true)]
       public string UnitNumber { get; set; }

       /// <summary>
       ///房号
       /// </summary>
       [Display(Name ="房号")]
       [MaxLength(25)]
       [Column(TypeName="nvarchar(25)")]
       [Editable(true)]
       public string HouseNumber { get; set; }

       /// <summary>
       ///所属单位
       /// </summary>
       [Display(Name ="所属单位")]
       [JsonIgnore]
       [Column(TypeName="int")]
       [Editable(true)]
       public int? BelongUnit { get; set; }

       /// <summary>
       ///地址
       /// </summary>
       [Display(Name ="地址")]
       [MaxLength(200)]
       [JsonIgnore]
       [Column(TypeName="nvarchar(200)")]
       [Editable(true)]
       public string HouseAddress { get; set; }

       /// <summary>
       ///房屋类别
       /// </summary>
       [Display(Name ="房屋类别")]
       [Column(TypeName="int")]
       [Editable(true)]
       public int? HouseType { get; set; }

       /// <summary>
       ///房屋状态
       /// </summary>
       [Display(Name ="房屋状态")]
       [Column(TypeName="int")]
       [Editable(true)]
       public int? HouseStatus { get; set; }

       /// <summary>
       ///房屋租金
       /// </summary>
       [Display(Name ="房屋租金")]
       [DisplayFormat(DataFormatString="10,2")]
       [Column(TypeName="decimal")]
       [Editable(true)]
       public decimal? RentFee { get; set; }

       /// <summary>
       ///是否启用
       /// </summary>
       [Display(Name ="是否启用")]
       [JsonIgnore]
       [Column(TypeName="int")]
       [Editable(true)]
       public int? EnableFlag { get; set; }

       /// <summary>
       ///创建人
       /// </summary>
       [Display(Name ="创建人")]
       [JsonIgnore]
       [Column(TypeName="int")]
       [Required(AllowEmptyStrings=false)]
       public int CreatorID { get; set; }

       /// <summary>
       ///创建人
       /// </summary>
       [Display(Name ="创建人")]
       [MaxLength(30)]
       [JsonIgnore]
       [Column(TypeName="nvarchar(30)")]
       [Required(AllowEmptyStrings=false)]
       public string Creator { get; set; }

       /// <summary>
       ///创建时间
       /// </summary>
       [Display(Name ="创建时间")]
       [JsonIgnore]
       [Column(TypeName="datetime")]
       public DateTime? CreateDate { get; set; }

       /// <summary>
       ///修改人
       /// </summary>
       [Display(Name ="修改人")]
       [JsonIgnore]
       [Column(TypeName="int")]
       public int? ModifyID { get; set; }

       /// <summary>
       ///修改人
       /// </summary>
       [Display(Name ="修改人")]
       [JsonIgnore]
       [Column(TypeName="datetime")]
       public DateTime? ModifyDate { get; set; }

       /// <summary>
       ///修改时间
       /// </summary>
       [Display(Name ="修改时间")]
       [MaxLength(30)]
       [JsonIgnore]
       [Column(TypeName="nvarchar(30)")]
       public string Modifier { get; set; }

       /// <summary>
       ///租赁状态
       /// </summary>
       [Display(Name ="租赁状态")]
       [Column(TypeName="int")]
       public int? RentStatus { get; set; }

       
    }
}
