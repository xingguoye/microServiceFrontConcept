import { useEffect, useState } from "react";
import "./Test.scss";
import axios from "axios";

interface dataType {
  id: number;
  name: string;
}

const Test = () => {
  const [data, setData] = useState<dataType[]>([]);

  useEffect(() => {
    axios.get("/test").then((res) => {
      setData(res.data.items as dataType[]);
    });
  }, []);

  return (
    <>
      {data.length > 0 ? (
        data.map((item: dataType) => (
          <div>
            <span className="test">
              {item.id}: {item.name}
            </span>
          </div>
        ))
      ) : (
        <span className="test">Sin dato</span>
      )}
    </>
  );
};

export default Test;
