﻿using IAGrim.StashFile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAGrim.Parser.Character {
    class GDCharRespawnList {
        private const int VERSION = 1;
        private const int BLOCK = 5;


        public void Read(GDCryptoDataBuffer reader) {
            reader.ReadBlockStart(BLOCK);

            int version = reader.ReadCryptoIntUnchecked();
            if (version != VERSION)
                throw new FormatException("ERR_UNSUPPORTED_VERSION");

            int numDifficulties = 3;
            for (int i = 0; i < numDifficulties; i++) {
                int length = reader.ReadCryptoIntUnchecked();
                for (int m = 0; m < length; m++) {
                    reader.ReadAndDiscardUID();
                }
            }

            int numSpawnPoints = 3; // Devils, Homestead, Fort Ikon
            for (int i = 0; i < numSpawnPoints; i++) {
                reader.ReadAndDiscardUID();
            }

            reader.ReadBlockEnd();
        }
    }
}
