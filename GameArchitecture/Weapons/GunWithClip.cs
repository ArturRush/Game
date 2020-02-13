using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameArchitecture.Weapons
{
	//TODO implement IThrowable and IMelee here
	/// <summary>
	/// It is a gun which uses gunClip
	/// </summary>
	public class GunWithClip : INamable, IShooter //, IThrowable, IMelee
	{
		public string Name { get; protected set; }
		public string Description { get; protected set; }
		public int FiringModeQuantity { get; protected set; }
		public float ShootDamage { get; protected set; }
		public float ShootRange { get; protected set; }

		/// <summary>
		/// Seconds
		/// </summary>
		public float ReloadTime { get; protected set; }

		public event Action<IShooter> OnShootStart;
		public event Action<IShooter, IShootable> OnShoot;
		public event Action<IShooter> OnShootEnd;
		public event Action<IShooter, GunClip> OnClipTakeOut;
		public event Action<IShooter, bool> OnClipPutIn;
		public event Action<IShooter, int> OnBulletNumChange;
		
		//TODO limit access to Clip from Gun
		private GunClip gunClip;

		/// <summary>
		/// List of GunClip.Name strings which compitable with this GunWithClip
		/// </summary>
		public List<string> CompatibleClips = new List<string>();

		public GunWithClip(string name, string description, int firingModeQuantity, float shootDamage, float shootRange,
			float reloadTime, List<string> compatibleClips)
		{
			Name = name;
			Description = description;
			FiringModeQuantity = firingModeQuantity;
			ShootDamage = shootDamage;
			ShootRange = shootRange;
			ReloadTime = reloadTime;
			CompatibleClips = compatibleClips;
		}

		public void ShootStart()
		{
			OnShootStart?.Invoke(this);
			Shoot();
		}

		public IShootable Shoot()
		{
			var res = gunClip?.Shoot();
			if (res != null) OnShoot?.Invoke(this, res);
			return res;
		}

		public void ShootEnd()
		{
			OnShootEnd?.Invoke(this);
		}
		
		/// <summary>
		/// Take out clip, then put new one
		/// </summary>
		/// <param name="clip">New clip to put</param>
		/// <returns>Old clip which was taken out</returns>
		public GunClip Reload(GunClip clip)
		{
			GunClip res = TakeOutClip();
			PutClip(clip);
			return res;
		}

		/// <summary>
		/// Take clip out from gun
		/// </summary>
		/// <returns>Old clip</returns>
		public GunClip TakeOutClip()
		{
			var res = gunClip;
			OnClipTakeOut?.Invoke(this, res);
			gunClip = null;
			return res;
		}

		/// <summary>
		/// Put compatible clip to gun
		/// </summary>
		/// <param name="clip">New clip to put</param>
		/// <returns>Was it put successfully?</returns>
		public bool PutClip(GunClip clip)
		{
			var res = false;
			if (CompatibleClips.Contains(clip.ToString()))
			{
				this.gunClip = clip;
				clip.OnBulletNumChange += Clip_OnBulletNumChange;
				res = true;
			}
			OnClipPutIn?.Invoke(this,res);
			return res;
		}

		/// <summary>
		/// Update how many bullets left in clip
		/// </summary>
		private void Clip_OnBulletNumChange(GunClip clip, int bulletNum)
		{
			OnBulletNumChange?.Invoke(this, bulletNum);
		}

		/// <summary>
		/// How many bullets left in clip
		/// </summary>
		/// <returns></returns>
		public int BulletsLeft()
		{
			if (gunClip == null) return 0;
			return gunClip.ShootablesLeftInClip;
		}

		public string ClipName()
		{
			if (gunClip == null) return "No clip in gun";
			return gunClip.Name;
		}

		public string ClipDescription()
		{
			if (gunClip == null) return "No clip in gun";
			return gunClip.Description;
		}

		/// <summary>
		/// Which shootables are in gunClip
		/// </summary>
		/// <returns>List of shootable names</returns>
		public List<string> GetShootablesInClip()
		{
			var res = new List<string>();

			if (gunClip == null) return res;
			res = gunClip.GetTypesOfShootables();

			return res;
		}

		public override string ToString()
		{
			return Name;
		}
	}
}