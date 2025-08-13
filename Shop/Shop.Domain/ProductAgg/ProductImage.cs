using Common.Domain;
using Common.Domain.Exceptions;

namespace Shop.Domain.ProductAgg
{
    public class ProductImage:BaseEntity
    {
        //Name Imag
        public string ImageName{ get; private set; }
        //Relation With Product
        public long ProductId { get;internal set; }
        //
        public int Sequence { get;private set; }
        //Set ProductImage
        public ProductImage(string imageName, int sequence)
        {
            NullOrEmptyDomainDataException.CheckString((imageName,nameof(imageName)));
            ImageName = imageName;
            Sequence = sequence;
        }
    }
}