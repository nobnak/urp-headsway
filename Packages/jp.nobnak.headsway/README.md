# HeadSway (jp.nobnak.headsway)

Fixed camera rig head sway using converging lens shift.

## Usage

Add `HeadSwayLensShiftCamera` to a `Camera`. Tune `ViewMotion.Params` and focus distance in the inspector.

## Sample

Import **HeadSway** from Package Manager → jp.nobnak.headsway → Samples.

### Development (this repository)

Edit the demo under `Assets/Samples/HeadSway`. Before a player build or publish, samples are copied to `Packages/jp.nobnak.headsway/Samples~/HeadSway` automatically (`IPreprocessBuildWithReport`), or manually via **jp.nobnak.headsway → Sync Samples to Package**.
