using NAudio.Midi;
using System.Collections;
using System.Collections.Generic;
using System.Linq;



namespace NK2Tray
{
    // Add definition of the AKAI Professional MPD232
    public class MPD232 : MidiDevice
    {
        public override string SearchString => "MPD232";

        public FaderDef FaderOne => new FaderDef(
            false,
            127f,
            1,
            true,
            false,
            false,
            false,
            0,
            0,
            0,
            0,
            0,
            MidiCommandCode.ControlChange,
            MidiCommandCode.ControlChange,
            MidiCommandCode.ControlChange,
            MidiCommandCode.ControlChange,
            MidiCommandCode.ControlChange
        );

        public MPD232(AudioDevice audioDevice)
        {
            audioDevices = audioDevice;
            FindMidiIn();
            FindMidiOut();

            if (!Found) return;

            InitFaders();
            InitButtons();
            LoadAssignments();
            ListenForMidi();

        }

        public override void ResetAllLights()
        {
            base.ResetAllLights();
        }

        public override void LightShow()
        {
            base.LightShow();
        }

        public override void SetVolumeIndicator(int fader, float level)
        {
            base.SetVolumeIndicator(fader, level);
        }

        public override void SetLight(int controller, bool state)
        {
            base.SetLight(controller, state);
        }

        public override void InitFaders()
        {
            faders = new List<Fader>
            {
                new Fader(this, 0, FaderOne),
                new Fader(this, 1, FaderOne),
                new Fader(this, 2, FaderOne),
                new Fader(this, 3, FaderOne),
                new Fader(this, 4, FaderOne),
                new Fader(this, 5, FaderOne),
                new Fader(this, 6, FaderOne),
                new Fader(this, 7, FaderOne),
            };
        }

        public override void InitButtons()
        {
            base.InitButtons();
        }
    }
}