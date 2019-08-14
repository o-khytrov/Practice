/******************************************************************************
Module:  Ch20-1-ExceptionHandling.cs
Notices: Copyright (c) 2013 Jeffrey Richter
******************************************************************************/

#if !DEBUG
#pragma warning disable 1058
#endif
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;

internal static class CodeContracts {
   public static void Go() {
      var shoppingCart = new ShoppingCart();
      shoppingCart.AddItem(new Item());
   }

   public sealed class Item { /* ... */ }

   public sealed class ShoppingCart {
      private List<Item> m_cart = new List<Item>();
      private Decimal m_totalCost = 0;

      public ShoppingCart() {
      }

      public void AddItem(Item item) {
         AddItemHelper(m_cart, item, ref m_totalCost);
      }

      private static void AddItemHelper(List<Item> m_cart, Item newItem, ref Decimal totalCost) {
         // Preconditions: 
         Contract.Requires(newItem != null);
         Contract.Requires(Contract.ForAll(m_cart, s => s != newItem));

         // Postconditions:
         Contract.Ensures(Contract.Exists(m_cart, s => s == newItem));
         Contract.Ensures(totalCost >= Contract.OldValue(totalCost));
         Contract.EnsuresOnThrow<IOException>(totalCost == Contract.OldValue(totalCost));

         // Do some stuff (which could throw an IOException)...
         m_cart.Add(newItem);
         totalCost += 1.00M;
         //throw new IOException(); // Prove contract violation
      }

      // Object invariant
      [ContractInvariantMethod]
      private void ObjectInvariant() {
         Contract.Invariant(m_totalCost >= 0);
      }
   }
}

//////////////////////////////// End of File //////////////////////////////////
