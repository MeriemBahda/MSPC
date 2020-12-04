(window.webpackJsonp=window.webpackJsonp||[]).push([[5],{74:function(e,t,n){"use strict";n.r(t),n.d(t,"frontMatter",(function(){return i})),n.d(t,"metadata",(function(){return c})),n.d(t,"rightToc",(function(){return s})),n.d(t,"default",(function(){return l}));var r=n(3),o=n(7),a=(n(0),n(95)),i={title:"Consensus peaks"},c={unversionedId:"method/consensus",id:"method/consensus",isDocsHomePage:!1,title:"Consensus peaks",description:"A consensus peak is created on a position of genome where is covered by at least one peak from the output sets of the processed replicates. Accordingly, a consensus peak has the following characteristics:",source:"@site/docs/method/consensus.md",slug:"/method/consensus",permalink:"/MSPC/docs/method/consensus",editUrl:"https://github.com/Genometric/MSPC/tree/dev/website/docs/method/consensus.md",version:"current",sidebar:"someSidebar",previous:{title:"Sets",permalink:"/MSPC/docs/method/sets"},next:{title:"About",permalink:"/MSPC/docs/cli/about"}},s=[],p={rightToc:s};function l(e){var t=e.components,n=Object(o.a)(e,["components"]);return Object(a.b)("wrapper",Object(r.a)({},p,n,{components:t,mdxType:"MDXLayout"}),Object(a.b)("p",null,"A consensus peak is created on a position of genome where is covered by at least one peak from the ",Object(a.b)("inlineCode",{parentName:"p"},"output")," sets of the processed replicates. Accordingly, a consensus peak has the following characteristics:"),Object(a.b)("ul",null,Object(a.b)("li",{parentName:"ul"},Object(a.b)("p",{parentName:"li"},Object(a.b)("strong",{parentName:"p"},"Coordinate")," (i.e., ",Object(a.b)("em",{parentName:"p"},"chromosome"),", ",Object(a.b)("em",{parentName:"p"},"start"),", and ",Object(a.b)("em",{parentName:"p"},"stop"),") ",Object(a.b)("br",null),"\nThe ",Object(a.b)("strong",{parentName:"p"},"coordinate")," of a consensus peak is the union of the coordinates of the peaks from ",Object(a.b)("inlineCode",{parentName:"p"},"output")," sets which overlap that position on the genome. For instance: "),Object(a.b)("pre",{parentName:"li"},Object(a.b)("code",Object(r.a)({parentName:"pre"},{}),"  // From the Output set of Replicate 1 \n  chr1    10    20    macs_peak_1    20.9\n\n  // From the Output set of Replicate 2 \n  chr1    15    25    macs_peak_1    14.6\n\n  // The resulting consensus peak \n  chr1    10    25    mspc_peak_1    163.484\nNote that the p-values are in `-log10` format. \n"))),Object(a.b)("li",{parentName:"ul"},Object(a.b)("p",{parentName:"li"},Object(a.b)("strong",{parentName:"p"},"Value")," ",Object(a.b)("br",null),"\nThe value of each consensus peak is ",Object(a.b)("inlineCode",{parentName:"p"},"X^2")," which is calculated by combining the ",Object(a.b)("inlineCode",{parentName:"p"},"p-value"),"s of the overlapping peaks using ",Object(a.b)("a",Object(r.a)({parentName:"p"},{href:"https://en.wikipedia.org/wiki/Fisher%27s_method"}),"Fisher's combined probability test"),":"),Object(a.b)("pre",{parentName:"li"},Object(a.b)("code",Object(r.a)({parentName:"pre"},{}),"  X_i^2 = -2 \\times \\sum_{i=1}^k \\ln(p_i)\n")))),Object(a.b)("p",null,"where ",Object(a.b)("inlineCode",{parentName:"p"},"X_i^2")," is the value of consensus peak ",Object(a.b)("inlineCode",{parentName:"p"},"i"),", and ",Object(a.b)("inlineCode",{parentName:"p"},"p_i")," is the p-value of overlapping peaks. For instance, the ",Object(a.b)("inlineCode",{parentName:"p"},"X^2")," of aforementioned consensus peaks is ",Object(a.b)("inlineCode",{parentName:"p"},"163.484"),", which is calculated by combining the p-values of overlapping peaks (i.e., ",Object(a.b)("inlineCode",{parentName:"p"},"20.9")," and ",Object(a.b)("inlineCode",{parentName:"p"},"14.6"),") using the ",Object(a.b)("a",Object(r.a)({parentName:"p"},{href:"https://en.wikipedia.org/wiki/Fisher%27s_method"}),"Fisher's method"),"."))}l.isMDXComponent=!0},95:function(e,t,n){"use strict";n.d(t,"a",(function(){return u})),n.d(t,"b",(function(){return d}));var r=n(0),o=n.n(r);function a(e,t,n){return t in e?Object.defineProperty(e,t,{value:n,enumerable:!0,configurable:!0,writable:!0}):e[t]=n,e}function i(e,t){var n=Object.keys(e);if(Object.getOwnPropertySymbols){var r=Object.getOwnPropertySymbols(e);t&&(r=r.filter((function(t){return Object.getOwnPropertyDescriptor(e,t).enumerable}))),n.push.apply(n,r)}return n}function c(e){for(var t=1;t<arguments.length;t++){var n=null!=arguments[t]?arguments[t]:{};t%2?i(Object(n),!0).forEach((function(t){a(e,t,n[t])})):Object.getOwnPropertyDescriptors?Object.defineProperties(e,Object.getOwnPropertyDescriptors(n)):i(Object(n)).forEach((function(t){Object.defineProperty(e,t,Object.getOwnPropertyDescriptor(n,t))}))}return e}function s(e,t){if(null==e)return{};var n,r,o=function(e,t){if(null==e)return{};var n,r,o={},a=Object.keys(e);for(r=0;r<a.length;r++)n=a[r],t.indexOf(n)>=0||(o[n]=e[n]);return o}(e,t);if(Object.getOwnPropertySymbols){var a=Object.getOwnPropertySymbols(e);for(r=0;r<a.length;r++)n=a[r],t.indexOf(n)>=0||Object.prototype.propertyIsEnumerable.call(e,n)&&(o[n]=e[n])}return o}var p=o.a.createContext({}),l=function(e){var t=o.a.useContext(p),n=t;return e&&(n="function"==typeof e?e(t):c(c({},t),e)),n},u=function(e){var t=l(e.components);return o.a.createElement(p.Provider,{value:t},e.children)},b={inlineCode:"code",wrapper:function(e){var t=e.children;return o.a.createElement(o.a.Fragment,{},t)}},m=o.a.forwardRef((function(e,t){var n=e.components,r=e.mdxType,a=e.originalType,i=e.parentName,p=s(e,["components","mdxType","originalType","parentName"]),u=l(n),m=r,d=u["".concat(i,".").concat(m)]||u[m]||b[m]||a;return n?o.a.createElement(d,c(c({ref:t},p),{},{components:n})):o.a.createElement(d,c({ref:t},p))}));function d(e,t){var n=arguments,r=t&&t.mdxType;if("string"==typeof e||r){var a=n.length,i=new Array(a);i[0]=m;var c={};for(var s in t)hasOwnProperty.call(t,s)&&(c[s]=t[s]);c.originalType=e,c.mdxType="string"==typeof e?e:r,i[1]=c;for(var p=2;p<a;p++)i[p]=n[p];return o.a.createElement.apply(null,i)}return o.a.createElement.apply(null,n)}m.displayName="MDXCreateElement"}}]);