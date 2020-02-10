using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameArchitecture.Weapons
{
	//TODO implement IThrowable
	public class GunClip : INamable //, IThrowable
	{
		public string Name { get; protected set; }
		public string Description { get; protected set; }
		public int ClipSize { get; protected set; }
		public List<string> CompatibleBullets = new List<string>();

		public int ShootablesLeftInClip
		{
			get => clip.Count;
		}

		public event Action OnNoBullets;
		/// <summary>
		/// Event shows how many bullets after update
		/// </summary>
		public event Action<int> OnBulletNumChange;

		private Queue<IShootable> clip = new Queue<IShootable>();

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
				OnBulletNumChange?.Invoke(ShootablesLeftInClip);
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
			// If there are < 2 bullets (1 or 0) then after shoot there will be no more bullets
			if (ShootablesLeftInClip < 2) OnNoBullets?.Invoke();
			if (ShootablesLeftInClip > 0)
			{
				var shootable = clip.Dequeue();
				OnBulletNumChange?.Invoke(ShootablesLeftInClip);
				return shootable;
			}
			return null;
		}

		public List<string> GetTypesOfShootables()
		{
			return clip.Select(x => x.ToString()).ToList();
		}

		public override string ToString()
		{
			return Name;
		}
	}
}