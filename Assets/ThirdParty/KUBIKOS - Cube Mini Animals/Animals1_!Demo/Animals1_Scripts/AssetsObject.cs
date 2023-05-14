using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Animmal.Animmals1
{
    [System.Serializable]
    public class SKINS
    {
        public List<Transform> Skins = new List<Transform>();
        public void SetSkin(int _SkinID)
        {
            for (int i = 0; i < Skins.Count; i++)
            {
                if (i == _SkinID)
                    Skins[i].gameObject.SetActive(true);
                else
                    Skins[i].gameObject.SetActive(false);
            }
        }
        public void HideAll()
        {
            for (int i = 0; i < Skins.Count; i++)
            {
                Skins[i].gameObject.SetActive(false);
            }
        }
    }
    public class AssetsObject : MonoBehaviour
    {
        
        public List<SKINS> Prefabs = new List<SKINS>();

        int CurrentID = 0;
        int CurrentSkin = 0;
        public void Init(List<AssetDB> _AssetDB)
        {
            for (int i = 0; i < _AssetDB.Count; i++)
            {
                SKINS _Skin = new SKINS();
                for (int j = 0; j < _AssetDB[i].AssetSkins.Skins.Count; j++)
                {
                    Transform _SkinItem = Instantiate(_AssetDB[i].AssetSkins.Skins[j], transform) as Transform;
                    _Skin.Skins.Add(_SkinItem);
                }
                Prefabs.Add(_Skin);
                if (i == 0)
                    Prefabs[i].SetSkin(0);
                else
                {
                    Prefabs[i].HideAll();
                }
            }           
        }

        public void SetObject(int _ObjectID)
        {
            Prefabs[CurrentID].HideAll();
            CurrentID = _ObjectID;
            SetSkin(0);
        }

        public int GetObjectTriangleCount()
        {
            int _Count = 0;


            Component[] _SkinnedMeshRenderers;


            _SkinnedMeshRenderers = Prefabs[CurrentID].Skins[CurrentSkin].gameObject.GetComponentsInChildren<SkinnedMeshRenderer>();

            foreach (SkinnedMeshRenderer _SkinnedMesh in _SkinnedMeshRenderers)
                _Count += _SkinnedMesh.sharedMesh.triangles.Length / 3;

            return _Count;

        }

        public void SetAnimation(string _AnimTrigger)
        {
            Prefabs[CurrentID].Skins[CurrentSkin].gameObject.GetComponent<Animator>().SetTrigger(_AnimTrigger);
        }


        public void SetSkin(int _Skin)
        {
            CurrentSkin = _Skin;
            Prefabs[CurrentID].SetSkin(_Skin);
        }
    }
}