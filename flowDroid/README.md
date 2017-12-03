FlowDroid framework

Usage:
detect data leakages in android apks.

Inputs:
1- Taint Wrappers as text file
2- Callbacks as text file
3- sources and sinks Of android API as text file(handly anotated and modified on the results of Susi framework)

Output:
1-xml file contains data leackages and its sinks and sources calls .

possible options:

--aliasflowins This option makes the alias search flow-insensitive and may generate more false positives, but on the other hand can greatly reduce runtime for large applications.
--aplength n Sets the maximum access path length to n. The default is 5. In general, larger values make the analysis more precise, but also more expensive.
--nostatic Disables tracking static fields. Makes the analysis faster, but may also miss some leaks.
--nocallbacks Disables the emulation of Android callbacks (button clicks, GPS location changes, etc.) This option reduces the runtime, but may miss some leaks.
--pathalgo Specifies the path reconstruction algorithm to be used. There are the following possibilities: 
"sourcesonly" just shows which sources are connected to which sinks, but does not reconstruct exact propagation paths. This path algorithm is context-insensitive by construction, but also the fastest algorithm.
"contextinsensitive" shows the complete propagation path from source to sink and is context-insensitive.
"contextsensitive" shows the complete propagation path from source to sink and is fully context-sensitive. It is the most precise, but also the slowest and most memory-demanding algorithm.
--nopaths Do not compute the exact propagation paths between source and sink, only report the source-and-sink pairs as such.
--noarraysize Do not distinguish between tainted array contents and tainted array lengths.
--IMPLICIT Enable implicit flows.
--NOEXCEPTIONS Disable exception tracking.
--CGALGO x Use callgraph algorithm x .
--LAYOUTMODE x Set UI control analysis mode to x .
--AGGRESSIVETW Use taint wrapper in aggressive mode
--SUMMARYPATH Path to library summaries
--SYSFLOWS Also analyze classes in system packages
--NOTAINTWRAPPER Disables the use of taint wrappers
--NOTYPECHECKING Do not propagate types along with taints
--LOGSOURCESANDSINKS Print out concrete source/sink instances
--CALLBACKANALYZER x Uses callback analysis algorithm x
--MAXTHREADNUM x Sets the maximum number of threads to be used by the analysis to x
--ONECOMPONENTATATIME Analyze one component at a time
--ONESOURCEATATIME Analyze one source at a time
--ALIASALGO x Use the aliasing algorithm x
--CODEELIMINATION x Use code elimination mode x
--ENABLEREFLECTION Enable support for reflective method calls
--SEQUENTIALPATHPROCESSING Process all taint paths sequentially
--SINGLEJOINPOINTABSTRACTION Only record one source per join point
--NOCALLBACKSOURCES Don't treat parameters of callback methods as sources

Supported callgraph algorithms: AUTO, CHA, RTA, VTA, SPARK, GEOM
Supported layout mode algorithms: NONE, PWD, ALL
Supported path algorithms: CONTEXTSENSITIVE, CONTEXTINSENSITIVE, SOURCESONLY
Supported callback algorithms: DEFAULT, FAST
Supported alias algorithms: NONE, PTSBASED, FLOWSENSITIVE, LAZY
Supported code elimination modes: NONE, PROPAGATECONSTS, REMOVECODE


