using System;
using System.Collections.Generic;
using System.Text;

namespace GoldBadge02_ClassLibrary
{
    public class KomodoClaimsRepo
    {
        private readonly Queue<KomodoClaimsContent> _claimDirectory = new Queue<KomodoClaimsContent>();

        public bool AddClaimToDirectory(KomodoClaimsContent claim)
        {
            int startingCount = _claimDirectory.Count;
            _claimDirectory.Enqueue(claim);
            bool wasAdded = (_claimDirectory.Count > startingCount) ? true : false;
            return wasAdded;
        }
        public Queue<KomodoClaimsContent> GetAllClaims()
        {
            return _claimDirectory;
        }
        public Queue<KomodoClaimsContent> LookAtNextClaim()
        {
            KomodoClaimsContent claim = new KomodoClaimsContent();
            _claimDirectory.Enqueue(claim);
            _claimDirectory.Peek();
            return _claimDirectory;
        }
        public Queue<KomodoClaimsContent> ProcessNextClaim()
        {
            KomodoClaimsContent claim = new KomodoClaimsContent();
            _claimDirectory.Enqueue(claim);
            _claimDirectory.Dequeue();
            return _claimDirectory;
        }
    }
}
