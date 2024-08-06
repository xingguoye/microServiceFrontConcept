import { defineConfig } from "vite";
import react from "@vitejs/plugin-react";
import federation from "@originjs/vite-plugin-federation";

// https://vitejs.dev/config/
export default defineConfig({
  plugins: [
    react(),
    federation({
      name: "test",
      filename: "remoteEntry.js",
      exposes: {
        "./Test": "./src/Test/Test.tsx",
      },
      shared: ["react", "react-dom"],
    }),
  ],
  server: {
    watch: {
      usePolling: true,
    },
    host: true, // needed for the Docker Container port mapping to work
    strictPort: true,
    port: 80, // you can replace this port with any port
  },
  build: {
    modulePreload: true,
    target: "esnext",
    minify: true,
    cssCodeSplit: true,
  },
});
