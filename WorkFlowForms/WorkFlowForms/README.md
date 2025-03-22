# WorkFlowForms

這是一個使用Vue.js構建的SPA（單頁應用程式）。

## 專案結構

```
WorkFlowForms/
└── wwwroot/
    ├── dist/          # 編譯後的檔案
    ├── src/
    │   └── js/        # JavaScript源碼
    ├── index.html     # HTML模板
    ├── package.json   # NPM配置
    └── webpack.config.js # Webpack配置
```

## 開發指南

### 前端開發環境設置

1. 安裝Node.js和npm（如果尚未安裝）
2. 在專案目錄中安裝依賴項：

```
cd WorkFlowForms/WorkFlowForms/wwwroot
npm install
```

### 自動啟動Webpack

專案已配置為在使用IDE啟動時自動運行Webpack：

- 使用**Debug**模式啟動專案時，會自動運行`npm run dev`並啟動Webpack監視模式（watch mode）
- 使用**Release**模式啟動專案時，會自動運行`npm run build`進行生產環境構建

不需要手動啟動Webpack，IDE會自動處理這些步驟。

### 手動Webpack指令

如需手動操作，在`WorkFlowForms/WorkFlowForms/wwwroot`目錄中，可以使用以下npm命令：

1. **開發模式編譯**
```
npm run dev
```

2. **生產模式編譯**
```
npm run build
```

3. **監視文件變更並自動重新編譯**
```
npm run watch
```

4. **啟動開發伺服器**
```
npm run serve
```
啟動後可以通過 http://localhost:9000 訪問應用。

### 部署

部署前請確保執行生產編譯：
```
npm run build
```

編譯後的檔案將會生成到`wwwroot/dist`目錄。

## 技術棧

- 前端框架: Vue.js 3
- 構建工具: Webpack 5
- 開發語言: JavaScript 