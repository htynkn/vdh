using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VideoDownloadHelper.Toudan
{
   public  class DataItem
    {
       public Message message { get; set; }
    }

   public class Message
   {
       public int count { get; set; }
       public List<DoudanItem> items { get; set; }
   }

   public class DoudanItem
   {
       /// <summary>
       /// 标题
       /// </summary>
       public String title { get; set; }
       /// <summary>
       /// 时长
       /// </summary>
       public String time { get; set; }
       /// <summary>
       /// 下载用编号
       /// </summary>
       public String itemId { get; set; }
       /// <summary>
       /// 上传者名称
       /// </summary>
       public String ownerNickname { get; set; }
   }
}
