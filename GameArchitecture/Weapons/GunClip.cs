using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameArchitecture.Weapons
{
	public abstract class GunClip: Item, IThrowable
	{
		public float ThrowDamage { get; set; }

		private int clipSize = 0;
		public int ClipSize { get => clipSize; set => clipSize = value; }

		public int ShootablesLeftInClip { get => clipSize - Clip.Count; }

		public Queue<IShootable> Clip = new Queue<IShootable>();

		/// <summary>
		/// Put shootables to clip
		/// </summary>
		/// <param name="shootable">What to push to clip</param>
		/// <param name="quantity">How much you want to push</param>
		/// <returns></returns>
		public virtual int ChargeClip(IShootable shootable, int quantity = 1)
		{
			//If not all shootables can be placed - return quantity of not placed shootables
			int notPuttedToClip = quantity;
			for (int i = 0; i < quantity; ++i)
			{
				if(Clip.Count == ClipSize)
					break;
				--notPuttedToClip;
				Clip.Enqueue(shootable);
			}
			return notPuttedToClip;
		}
	}
}
