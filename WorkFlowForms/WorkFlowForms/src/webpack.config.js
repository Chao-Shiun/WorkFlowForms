const path = require('path');
const TerserPlugin = require('terser-webpack-plugin');
const HtmlWebpackPlugin = require('html-webpack-plugin');
const { VueLoaderPlugin } = require('vue-loader');

module.exports = (env, argv) => {
    const isProduction = argv.mode === 'production';

    return {
        entry: './index.js',
        output: {
            filename: 'js/bundle.js',
            path: path.resolve(__dirname, '../wwwroot/dist'),
            clean: true
        },
        module: {
            rules: [
                {
                    test: /\.js$/,
                    exclude: /node_modules/,
                    use: {
                        loader: 'babel-loader'
                    }
                },
                {
                    test: /\.vue$/,
                    use: 'vue-loader'
                },
                {
                    test: /\.css$/,
                    use: [
                        'style-loader',
                        'css-loader'
                    ]
                }
            ]
        },
        resolve: {
            extensions: ['.js', '.vue', '.json']
        },
        devServer: {
            static: {
                directory: path.join(__dirname, '../wwwroot/dist')
            },
            compress: true,
            port: 9000,
            hot: true
        },
        devtool: isProduction ? false : 'source-map',
        optimization: {
            minimize: isProduction,
            minimizer: [
                new TerserPlugin({
                    terserOptions: {
                        compress: true,
                        mangle: true
                    }
                })
            ]
        },
        plugins: [
            new VueLoaderPlugin(),
            new HtmlWebpackPlugin({
                template: path.resolve(__dirname, 'index.html'),
                filename: path.resolve(__dirname, '../wwwroot/index.html'),
                inject: true
            })
        ]
    };
}; 