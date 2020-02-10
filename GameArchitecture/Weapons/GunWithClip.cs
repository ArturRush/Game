using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameArchitecture.Weapons
{
	//TODO implement IThrowable and IMelee here
	public class GunWithClip : INamable, IShooter//, IThrowable, IMelee
	{
		public string Name { get; protected set; }
		public string Description { get; protected set; }
		public int FiringModeQuantity { get; protected set; }
		public float ShootDamage { get; protected set; }
		public float ShootRange { get; protected set; }

		public float ReloadTime { get; protected set; }

		public event Action OnShootStart;
		public event Action OnShoot;
		public event Action OnShootEnd;
		public event Action OnClipTakeOut;
		public event Action OnClipPutIn;

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
			OnShootStart?.Invoke();
			Shoot();
		}

		public IShootable Shoot()
		{
			OnShoot?.Invoke();
			return clip?.Shoot();
		}

		public void ShootEnd()
		{
			OnShootEnd?.Invoke();
		}

		public GunClip Reload(GunClip clip)
		{
			GunClip res = TakeOutClip();
			PutClip(clip);
			return res;
		}

		public GunClip TakeOutClip()
		{
			OnClipTakeOut?.Invoke();
			var res = clip;
			clip = null;
			return res;
		}

		public bool PutClip(GunClip clip)
		{
			OnClipPutIn?.Invoke();
			if (!CompatibleClips.Contains(clip.ToString()))
				return false;
			this.clip = clip;
			return true;
		}

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