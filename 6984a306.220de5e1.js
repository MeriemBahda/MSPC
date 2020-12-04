(window.webpackJsonp=window.webpackJsonp||[]).push([[9],{78:function(e,t,n){"use strict";n.r(t),n.d(t,"frontMatter",(function(){return o})),n.d(t,"metadata",(function(){return c})),n.d(t,"rightToc",(function(){return s})),n.d(t,"default",(function(){return l}));var r=n(3),a=n(7),i=(n(0),n(95)),o={title:"Quick Start"},c={unversionedId:"quick_start",id:"quick_start",isDocsHomePage:!1,title:"Quick Start",description:"Preparation",source:"@site/docs/quick_start.md",slug:"/quick_start",permalink:"/MSPC/docs/quick_start",editUrl:"https://github.com/Genometric/MSPC/tree/dev/website/docs/quick_start.md",version:"current",sidebar:"someSidebar",previous:{title:"Welcome",permalink:"/MSPC/docs/"},next:{title:"Installation",permalink:"/MSPC/docs/installation"}},s=[{value:"Preparation",id:"preparation",children:[]},{value:"Run",id:"run",children:[]},{value:"Output",id:"output",children:[]},{value:"See Also",id:"see-also",children:[]}],p={rightToc:s};function l(e){var t=e.components,n=Object(a.a)(e,["components"]);return Object(i.b)("wrapper",Object(r.a)({},p,n,{components:t,mdxType:"MDXLayout"}),Object(i.b)("h2",{id:"preparation"},"Preparation"),Object(i.b)("ol",null,Object(i.b)("li",{parentName:"ol"},Object(i.b)("p",{parentName:"li"},"Install a self-contained release of MSPC, using either of following commands\ndepending on your runtime (see ",Object(i.b)("a",Object(r.a)({parentName:"p"},{href:"/MSPC/docs/installation"}),"installation")," page for detailed\ninstallation options): "),Object(i.b)("pre",{parentName:"li"},Object(i.b)("code",Object(r.a)({parentName:"pre"},{}),"```bash\n# Windows x64 (using PowerShell):\n$ wget -O mspc.zip https://github.com/Genometric/MSPC/releases/latest/download/win-x64.zip\n    \n# Linux x64:\n$ wget -O mspc.zip https://github.com/Genometric/MSPC/releases/latest/download/linux-x64.zip\n\n# macOS x64:\n$ wget -O mspc.zip https://github.com/Genometric/MSPC/releases/latest/download/osx-x64.zip\n```\n"))),Object(i.b)("li",{parentName:"ol"},Object(i.b)("p",{parentName:"li"},"Extract the downloaded archive and browse to the containing directory:"),Object(i.b)("pre",{parentName:"li"},Object(i.b)("code",Object(r.a)({parentName:"pre"},{className:"language-bash"}),"$ unzip mspc.zip -d mspc\n$ cd mspc\n"))),Object(i.b)("li",{parentName:"ol"},Object(i.b)("p",{parentName:"li"},"Download sample data:"),Object(i.b)("pre",{parentName:"li"},Object(i.b)("code",Object(r.a)({parentName:"pre"},{className:"language-bash"}),"$ wget -O demo.zip https://github.com/Genometric/Annotations/raw/master/SampleFiles/demo.zip\n$ unzip demo.zip -d .\n")))),Object(i.b)("h2",{id:"run"},"Run"),Object(i.b)("p",null,"To run MSPC use the following command depending on your runtime:"),Object(i.b)("pre",null,Object(i.b)("code",Object(r.a)({parentName:"pre"},{className:"language-bash"}),"# Windows x64 (using PowerShell):\n$ .\\mspc.exe -i .\\rep1.bed -i .\\rep2.bed -r bio -w 1e-4 -s 1e-8\n\n# Linux x64 or macOS x64:\n$ ./mspc.dll -i .\\rep1.bed -i .\\rep2.bed -r bio -w 1e-4 -s 1e-8\n")),Object(i.b)("h2",{id:"output"},"Output"),Object(i.b)("p",null,"MSPC creates a folder in the current execution path named ",Object(i.b)("inlineCode",{parentName:"p"},"session_X_Y"),", where ",Object(i.b)("inlineCode",{parentName:"p"},"X")," and ",Object(i.b)("inlineCode",{parentName:"p"},"Y")," are execution date and time respectively, which contains the following files and folders:"),Object(i.b)("pre",null,Object(i.b)("code",Object(r.a)({parentName:"pre"},{className:"language-bash"}),".\n\u2514\u2500\u2500 session_20191126_222131330\n    \u251c\u2500\u2500 ConsensusPeaks.bed\n    \u251c\u2500\u2500 ConsensusPeaks_mspc_peaks.txt\n    \u251c\u2500\u2500 EventsLog_20191126_2221313409928.txt\n    \u251c\u2500\u2500 rep1\n    \u2502\xa0\xa0 \u251c\u2500\u2500 Background.bed\n    \u2502\xa0\xa0 \u251c\u2500\u2500 Background_mspc_peaks.txt\n    \u2502\xa0\xa0 \u251c\u2500\u2500 Confirmed.bed\n    \u2502\xa0\xa0 \u251c\u2500\u2500 Confirmed_mspc_peaks.txt\n    \u2502\xa0\xa0 \u251c\u2500\u2500 Discarded.bed\n    \u2502\xa0\xa0 \u251c\u2500\u2500 Discarded_mspc_peaks.txt\n    \u2502\xa0\xa0 \u251c\u2500\u2500 FalsePositive.bed\n    \u2502\xa0\xa0 \u251c\u2500\u2500 FalsePositive_mspc_peaks.txt\n    \u2502\xa0\xa0 \u251c\u2500\u2500 Stringent.bed\n    \u2502\xa0\xa0 \u251c\u2500\u2500 Stringent_mspc_peaks.txt\n    \u2502\xa0\xa0 \u251c\u2500\u2500 TruePositive.bed\n    \u2502\xa0\xa0 \u251c\u2500\u2500 TruePositive_mspc_peaks.txt\n    \u2502\xa0\xa0 \u2514\u2500\u2500 Weak.bed\n    \u2502\xa0\xa0 \u251c\u2500\u2500 Weak_mspc_peaks.txt\n    \u2514\u2500\u2500 rep2\n     \xa0\xa0 \u251c\u2500\u2500 Background.bed\n     \xa0\xa0 \u251c\u2500\u2500 Background_mspc_peaks.txt\n     \xa0\xa0 \u251c\u2500\u2500 Confirmed.bed\n     \xa0\xa0 \u251c\u2500\u2500 Confirmed_mspc_peaks.txt\n     \xa0\xa0 \u251c\u2500\u2500 Discarded.bed\n     \xa0\xa0 \u251c\u2500\u2500 Discarded_mspc_peaks.txt\n     \xa0\xa0 \u251c\u2500\u2500 FalsePositive.bed\n     \xa0\xa0 \u251c\u2500\u2500 FalsePositive_mspc_peaks.txt\n     \xa0\xa0 \u251c\u2500\u2500 Stringent.bed\n      \xa0 \u251c\u2500\u2500 Stringent_mspc_peaks.txt\n     \xa0\xa0 \u251c\u2500\u2500 TruePositive.bed\n     \xa0\xa0 \u251c\u2500\u2500 TruePositive_mspc_peaks.txt\n     \xa0\xa0 \u2514\u2500\u2500 Weak.bed\n        \u2514\u2500\u2500 Weak.bed\n")),Object(i.b)("h2",{id:"see-also"},"See Also"),Object(i.b)("ul",null,Object(i.b)("li",{parentName:"ul"},Object(i.b)("a",Object(r.a)({parentName:"li"},{href:"/MSPC/docs/"}),"Welcome page")),Object(i.b)("li",{parentName:"ul"},Object(i.b)("a",Object(r.a)({parentName:"li"},{href:"/MSPC/docs/cli/input"}),"Input file format")),Object(i.b)("li",{parentName:"ul"},Object(i.b)("a",Object(r.a)({parentName:"li"},{href:"/MSPC/docs/cli/output"}),"Output files"))))}l.isMDXComponent=!0},95:function(e,t,n){"use strict";n.d(t,"a",(function(){return b})),n.d(t,"b",(function(){return m}));var r=n(0),a=n.n(r);function i(e,t,n){return t in e?Object.defineProperty(e,t,{value:n,enumerable:!0,configurable:!0,writable:!0}):e[t]=n,e}function o(e,t){var n=Object.keys(e);if(Object.getOwnPropertySymbols){var r=Object.getOwnPropertySymbols(e);t&&(r=r.filter((function(t){return Object.getOwnPropertyDescriptor(e,t).enumerable}))),n.push.apply(n,r)}return n}function c(e){for(var t=1;t<arguments.length;t++){var n=null!=arguments[t]?arguments[t]:{};t%2?o(Object(n),!0).forEach((function(t){i(e,t,n[t])})):Object.getOwnPropertyDescriptors?Object.defineProperties(e,Object.getOwnPropertyDescriptors(n)):o(Object(n)).forEach((function(t){Object.defineProperty(e,t,Object.getOwnPropertyDescriptor(n,t))}))}return e}function s(e,t){if(null==e)return{};var n,r,a=function(e,t){if(null==e)return{};var n,r,a={},i=Object.keys(e);for(r=0;r<i.length;r++)n=i[r],t.indexOf(n)>=0||(a[n]=e[n]);return a}(e,t);if(Object.getOwnPropertySymbols){var i=Object.getOwnPropertySymbols(e);for(r=0;r<i.length;r++)n=i[r],t.indexOf(n)>=0||Object.prototype.propertyIsEnumerable.call(e,n)&&(a[n]=e[n])}return a}var p=a.a.createContext({}),l=function(e){var t=a.a.useContext(p),n=t;return e&&(n="function"==typeof e?e(t):c(c({},t),e)),n},b=function(e){var t=l(e.components);return a.a.createElement(p.Provider,{value:t},e.children)},u={inlineCode:"code",wrapper:function(e){var t=e.children;return a.a.createElement(a.a.Fragment,{},t)}},d=a.a.forwardRef((function(e,t){var n=e.components,r=e.mdxType,i=e.originalType,o=e.parentName,p=s(e,["components","mdxType","originalType","parentName"]),b=l(n),d=r,m=b["".concat(o,".").concat(d)]||b[d]||u[d]||i;return n?a.a.createElement(m,c(c({ref:t},p),{},{components:n})):a.a.createElement(m,c({ref:t},p))}));function m(e,t){var n=arguments,r=t&&t.mdxType;if("string"==typeof e||r){var i=n.length,o=new Array(i);o[0]=d;var c={};for(var s in t)hasOwnProperty.call(t,s)&&(c[s]=t[s]);c.originalType=e,c.mdxType="string"==typeof e?e:r,o[1]=c;for(var p=2;p<i;p++)o[p]=n[p];return a.a.createElement.apply(null,o)}return a.a.createElement.apply(null,n)}d.displayName="MDXCreateElement"}}]);