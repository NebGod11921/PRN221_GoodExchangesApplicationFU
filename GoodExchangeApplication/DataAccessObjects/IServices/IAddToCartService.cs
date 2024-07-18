using DataAccessObjects.ViewModels.CartDTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects.IServices
{
    public interface IAddToCartService
    {
        public List<CartDTOs> getAllCart();
        public int GetCartIdNew();
        public int GetItemIdNew(int cartID);
        public CartDTOs getCartByID(int id);
        public ItemDTOS getItemByID(int id);
        public List<ItemDTOS> getItemByCartId(int id);
        public void AddToCart(CartDTOs cart);
        public void DeleteCartAll();
        public void DeleteItemInCart(int cartid, int itemid);
        public void UpdateCartItems(List<ItemDTOS> updatedItems);
        public void UpdateCartItem(ItemDTOS updatedItem);
    }
}
