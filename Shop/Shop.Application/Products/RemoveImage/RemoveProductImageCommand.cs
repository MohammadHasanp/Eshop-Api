using Common.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Products.RemoveImage
{
    public class RemoveProductImageCommand:IBaseCommand
    {
        public long productId { get; private set; }
        public long ImageId { get; set; }

        public RemoveProductImageCommand(long productId, long imageId)
        {
            this.productId = productId;
            ImageId = imageId;
        }
    }
}
