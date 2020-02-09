using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameArchitecture.Weapons
{
	//TODO implement IThrowable
	public class GunClip : INamable//, IThrowable
	{
		public string Name { get; protected set; }
		public string Description { get; protected set; }
		public int ClipSize { get; protected set; }
		public List<string> CompatibleBullets = new List<string>();

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

		public GunClip(string name, string description, int clipSize, List<string> compatibleBullets)
		{
			Name = name;
			Description = description;
			ClipSize = clipSize;
			CompatibleBullets = compatibleBullets;
		}

		/// <summary>
		/// Put shootables to clip
		/// </summary>
		/// <param name="shootable">What to push to clip</param>
		/// <returns>How much bullets are not placed it clip</returns>
		public bool ChargeClip(IShootable shootable)
		{
			if (ShootablesLeftInClip < ClipSize && CompatibleBullets.Contains(shootable.ToString()))
			{
				clip.Enqueue(shootable);
				return true;
			}
			return false;
		}


		/// <summary>
		/// Charge clip with list of shootables
		/// </summary>
		/// <param name="shootables"></param>
		/// <returns>List of shootables, which wasn't charged</returns>
		public List<IShootable> ChargeClip(List<IShootable> shootables)
		{
			List<IShootable> notCharged = new List<IShootable>();
			foreach (var shootable in shootables)
			{
				if (!ChargeClip(shootable))
					notCharged.Add(shootable);
			}
			return notCharged;
		}

		/// <summary>
		/// Shoot - will take one shootable from the clip
		/// </summary>
		/// <returns>Shootable or null</returns>
		public IShootable Shoot()
		{
			if (ShootablesLeftInClip > 0)
			{
				var shootable = Clip.Dequeue();
				return shootable;
			}
			return null;
		}

		public List<string> GetTypesOfShootables()
		{
			return Clip.Select(x=>x.ToString()).ToList();
		}

		public override string ToString()
		{
			return Name;
		}
	}
}