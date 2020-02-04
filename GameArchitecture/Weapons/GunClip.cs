using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameArchitecture.Weapons
{
	public abstract class GunClip : INamable, IThrowable
	{
		public string Name { get; protected set; }
		public string Description { get; protected set; }

		public float ThrowDamage { get; protected set; }

		public int ClipSize { get; protected set; }

		public int ShootablesLeftInClip
		{
			get => Clip.Count;
		}

		private Queue<IShootable> clip = new Queue<IShootable>();

		protected Queue<IShootable> Clip
		{
			get => clip;
			set => clip = value;
		}

		/// <summary>
		/// Create empty clip
		/// </summary>
		protected GunClip()
		{
			Clip = new Queue<IShootable>();
		}

		/// <summary>
		/// Create and fill clip with shootables
		/// </summary>
		/// <param name="shootables"></param>
		protected GunClip(List<IShootable> shootables)
		{
			throw new NotImplementedException("Implement this constructor for your class. In constructor check type of shootables");
		}

		/// <summary>
		/// Put shootables to clip
		/// </summary>
		/// <param name="shootable">What to push to clip</param>
		/// <returns>How much bullets are not placed it clip</returns>
		public virtual bool ChargeClip(IShootable shootable)
		{
			if (ShootablesLeftInClip < ClipSize)
			{
				clip.Enqueue(shootable);
				return true;
			}
			return false;
		}

		/// <summary>
		/// Shoot - will take one shootable from the clip
		/// </summary>
		/// <returns>Shooted - true, no shootables - false</returns>
		public bool Shoot()
		{
			if (ShootablesLeftInClip > 0)
			{
				Clip.Dequeue();
				return true;
			}
			return false;
		}

		public List<IShootable> GetTypesOfShootables()
		{
			return Clip.ToList();
		}
	}
}