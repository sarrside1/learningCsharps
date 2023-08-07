using System;
namespace HRAdministrationAPI
{
    // Déclaration d'une classe statique générique FactoryPattern avec deux paramètres de type K et T.
    public static class FactoryPattern<K,T> where T:class, K, new()
	{
        // Méthode statique pour obtenir une instance de type K.
        public static K GetInstance()
		{
			K objk;
			objk = new T();// Crée une instance de type T.
            return objk;
		}
	}
}

