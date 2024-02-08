using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarkovPacketSer.BSG_Enums;

namespace TarkovPacketSer.BSG_Classes
{
    internal class VoipQualitySettings
    {
        public static VoipQualitySettings Default { get; } = new VoipQualitySettings
        {
            FrameSize = FrameSize.Medium,
            AudioQuality = AudioQuality.Medium,
            ForwardErrorCorrection = true,
            NoiseSuppression = NoiseSuppressionLevels.High,
            SensitivityLevels = VadSensitivityLevels.MediumSensitivity
        };
        public void Deserialize(BinaryReader reader)
        {
            this.FrameSize = (FrameSize)reader.ReadByte();
            this.AudioQuality = (AudioQuality)reader.ReadByte();
            this.ForwardErrorCorrection = reader.ReadBoolean();
            this.NoiseSuppression = (NoiseSuppressionLevels)reader.ReadByte();
            this.SensitivityLevels = (VadSensitivityLevels)reader.ReadByte();
        }
        public FrameSize FrameSize;
        public AudioQuality AudioQuality;
        public bool ForwardErrorCorrection;
        public NoiseSuppressionLevels NoiseSuppression;
        public VadSensitivityLevels SensitivityLevels;
    }
}
