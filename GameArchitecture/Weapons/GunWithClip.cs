using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameArchitecture.Weapons
{
	//TODO implement IThrowable and IMelee here
	/// <summary>
	/// It is a gun which uses clip
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

		public event Action<object> OnShootStart;
		public event Action<object, IShootable> OnShoot;
		public event Action<object> OnShootEnd;
		public event Action<object, GunClip> OnClipTakeOut;
		public event Action<object, bool> OnClipPutIn;
		public event Action<object,int> OnBulletNumChange;
		
		//TODO limit access to Clip from Gun
		private GunClip clip;

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
			var res = clip?.Shoot();
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
			var res = clip;
			OnClipTakeOut?.Invoke(this, res);
			clip = null;
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
				this.clip = clip;
				clip.OnBulletNumChange += Clip_OnBulletNumChange;
				res = true;
			}
			OnClipPutIn?.Invoke(this,res);
			return res;
		}

		/// <summary>
		/// Update hiw many bullets left in clip
		/// </summary>
		private void Clip_OnBulletNumChange(object gunClip, int bulletNum)
		{
			OnBulletNumChange?.Invoke(this, bulletNum);
		}

		/// <summary>
		/// How many bullets left in clip
		/// </summary>
		/// <returns></returns>
		public int BulletsLeft()
		{
			if (clip == null) return 0;
			return clip.ShootablesLeftInClip;
		}

		public string ClipName()
		{
			if (clip == null) return "No clip in gun";
			return clip.Name;
		}

		public string ClipDescription()
		{
			if (clip == null) return "No clip in gun";
			return clip.Description;
		}

		/// <summary>
		/// Which shootables are in clip
		/// </summary>
		/// <returns>List of shootable names</returns>
		public List<string> GetShootablesInClip()
		{
			var res = new List<string>();

			if (clip == null) return res;
			res = clip.GetTypesOfShootables();

			return res;
		}

		public override string ToString()
		{
			return Name;
		}
	}
}